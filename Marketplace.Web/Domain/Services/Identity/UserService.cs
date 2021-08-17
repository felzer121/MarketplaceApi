using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.Domain.Models.Identities;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Domain.Services.Identity
{
    public class UserService : IUserService
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IJwtGenerator _jwtGenerator;
		private readonly DataContext _context;

		public UserService(
			UserManager<ApplicationUser> userManager, 
			SignInManager<ApplicationUser> signInManager, 
			IJwtGenerator jwtGenerator, 
			DataContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
			_context = context;
		}

        public async Task<UserDto> Login(LoginDto request)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new UnauthorizedAccessException();
			}
			
			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				var roles = await _userManager.GetRolesAsync(user);
				return new UserDto
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Patronymic = user.Patronymic,
					Token = _jwtGenerator.CreateToken(user, roles.ToList()),
					UserName = user.UserName,
					Image = null,
					Roles = roles.ToList()
				};
			}

			throw new UnauthorizedAccessException();
		}

		public async Task<UserDto> Register(RegistrationDto request)
        {
	        if (await _context.Users.Where(x => x.Email == request.Email).AnyAsync())
	        {
		        throw new Exception("Email already exist");
	        }

	        if (await _context.Users.Where(x => x.UserName == request.UserName).AnyAsync())
	        {
		        throw new Exception("UserName already exist");
	        }

	        var newUser = new ApplicationUser
	        {
		        FirstName = request.FirstName,
		        LastName = request.LastName,
		        Patronymic = request.Patronymic,
		        Email = request.Email,
		        UserName = request.UserName
	        };

	        var result = await _userManager.CreateAsync(newUser, request.Password);
	        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email); 
			await _userManager.AddToRoleAsync(user, AppRole.Buyer);

	        if (result.Succeeded)
	        {
		        var roles = await _userManager.GetRolesAsync(user);

		        return new UserDto
		        {
			        FirstName = request.FirstName,
			        LastName = request.LastName,
			        Patronymic = request.Patronymic,
			        Token = _jwtGenerator.CreateToken(newUser, roles.ToList()),
			        UserName = newUser.UserName,
			        Image = null,
			        Roles = roles.ToList()
		        };
	        }

	        throw new Exception("Client creation failed");
        }
	}

	public static class AppRole
    {
		public const string Admin = "admin";
		public const string Buyer = "buyer";
		public const string Seller = "seller";
		public const string BuyerSeller = "buyer,seller";
		public const string BuyerAdmin = "buyer,admin";
		public const string SellerAdmin = "seller,admin";
    }
}

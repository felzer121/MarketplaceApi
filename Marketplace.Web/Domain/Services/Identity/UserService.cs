using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.Domain.Models.Identity;
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
				return new UserDto
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Patronymic = user.Patronymic,
					Token = _jwtGenerator.CreateToken(user),
					UserName = user.UserName,
					Image = null
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

	        var user = new ApplicationUser
	        {
		        FirstName = request.FirstName,
		        LastName = request.LastName,
		        Patronymic = request.Patronymic,
		        Email = request.Email,
		        UserName = request.UserName
	        };

	        var result = await _userManager.CreateAsync(user, request.Password);

	        if (result.Succeeded)
	        {
		        return new UserDto
		        {
			        FirstName = request.FirstName,
			        LastName = request.LastName,
			        Patronymic = request.Patronymic,
			        Token = _jwtGenerator.CreateToken(user),
			        UserName = user.UserName,
			        Image = null
		        };
	        }

	        throw new Exception("Client creation failed");
        }
	}

}

using Marketplace.Web.DataAccess.Entities;
using Marketplace.Web.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Marketplace.Web.Domain.Services.Identity
{
    public class UserService
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IJwtGenerator _jwtGenerator;

		public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtGenerator jwtGenerator)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_jwtGenerator = jwtGenerator;
		}

		public async Task<ApplicationUser> Login(LoginDto request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				throw new RestException(HttpStatusCode.Unauthorized);
			}

			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

			if (result.Succeeded)
			{
				return new User
				{
					DisplayName = user.DisplayName,
					Token = _jwtGenerator.CreateToken(user),
					UserName = user.UserName,
					Image = null
				};
			}

			throw new RestException(HttpStatusCode.Unauthorized);
		}

		public async Task<ApplicationUser> Register()
        {
			return new ApplicationUser();
        }
	}

}

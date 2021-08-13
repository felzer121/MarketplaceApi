using System.Threading.Tasks;
using Marketplace.Web.Domain.Models.Identity;
using Marketplace.Web.Domain.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("identity")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _userService.Login(request);
            
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDto request)
        {
            var result = await _userService.Register(request);
            
            return Ok(result);
        }
    }
}

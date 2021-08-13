using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("identity")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}

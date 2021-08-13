using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

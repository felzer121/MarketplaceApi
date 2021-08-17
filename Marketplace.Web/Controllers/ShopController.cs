using System.Threading.Tasks;
using Marketplace.Web.Domain.Models.Shops;
using Marketplace.Web.Domain.Services.Shops;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/shop")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ShopDto shopDto)
        {
            var result = await _shopService.Create(shopDto);
            
            
            return Ok(result);
        }
    }
}
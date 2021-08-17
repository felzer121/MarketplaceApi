using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Marketplace.Web.Domain.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Marketplace.Web.Domain.Services.Identity;

namespace Marketplace.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme )]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll(int take = 10, int skip = 0)
        {
            var result = _productService.GetAll(take, skip);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = AppRole.BuyerAdmin)]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _productService.Create(product);
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = AppRole.SellerAdmin)]
        public async Task<IActionResult> Update(Product product)
        {
            await _productService.Update(product);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = AppRole.SellerAdmin)]
        public async Task<IActionResult> Delete(Product product)
        {
            await _productService.Delete(product);
            return Ok();
        }
    }
}

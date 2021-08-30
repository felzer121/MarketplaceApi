using System;
using System.Linq;
using Marketplace.Web.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [ApiController]
    [Route("main-page")]
    public class MainPageController : ControllerBase
    {
        private readonly DataContext _context;

        public MainPageController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("sales")]
        public IActionResult GetSales()
        {
            var result = _context.Sales.Where(x => x.FinishDate >= DateTime.UtcNow).ToList();
            
            return Ok(new {data = result});
        }
        
        [HttpGet("pair")]
        public IActionResult GetPairCategories(int take = 2)
        {
            var result = _context.Categories.Where(x => x.IsPublishedOnMainPage)
                .OrderByDescending(x => x.CreatedAt).Take(take).ToList();
            
            return Ok(new {data = result});
        }

        [HttpGet("products-for-you")]
        public IActionResult GetProductsForYou(int take = 50)
        {
            var result = _context.Products.OrderByDescending(x => x.CreatedAt).Take(take).ToList();
            
            return Ok(new {data = result});
        }

        public IActionResult GetSaleProducts(int take = 50)
        {
            var result = _context.Products.OrderByDescending(x => x.Sale).Take(take).ToList();

            return Ok(new {data = result});
        }
    }
}
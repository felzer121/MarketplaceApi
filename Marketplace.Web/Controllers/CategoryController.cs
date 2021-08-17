using System.Threading.Tasks;
using Marketplace.Web.Domain.Models.Categories;
using Marketplace.Web.Domain.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.Create(categoryDto);

            return Ok();
        }
    }
}
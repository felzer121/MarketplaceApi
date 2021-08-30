using System.Linq;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.Domain.Models.Categories;
using Marketplace.Web.Domain.Services.Categories;
using Marketplace.Web.Domain.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.Web.Controllers.Admin
{
    [ApiController]
    [Authorize(Roles = AppRole.Admin)]
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly DataContext _context;

        public AdminCategoryController(ICategoryService categoryService, DataContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            await _categoryService.Create(categoryDto);

            return Ok();
        }
    }
}
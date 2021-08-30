using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.DataAccess.Entities;
using Marketplace.Web.Domain.Models.Categories;
using Marketplace.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Marketplace.Web.Domain.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly ILogger _logger;
        
        public CategoryService(DataContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger<CategoryService>();
        }

        public async Task Create(CategoryDto category)
        {
            if (category == null)
            {
                _logger.LogError("Invalid input data");
                return;
            }

            await _context.Categories.AddAsync(new Category
            {
                Icon = category.Icon,
                Name = category.Name,
                ParentId = category.ParentCategoryId
            });
            await _context.SaveChangesAsync();
        }

        public List<Category> GetAll()
        {
            var all = _context.Categories.Include(x => x.Parent).ToList();
            var virtualRootNode = all.ToTree((parent, child) => child.ParentId == parent.Id);
            var rootLevelFoldersWithSubTree = virtualRootNode.Children.Select(x => x.Data).ToList();

            return rootLevelFoldersWithSubTree;
        }
    }
}
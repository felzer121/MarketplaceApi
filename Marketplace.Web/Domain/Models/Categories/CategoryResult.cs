using System.Collections.Generic;

namespace Marketplace.Web.Domain.Models.Categories
{
    public class CategoryResult
    {
        public CategoryDto CurrentCategory { get; set; }
        public List<CategoryDto> SubCategories { get; set; }
        public List<CategoryDto> ParentCategories { get; set; }
    }
}
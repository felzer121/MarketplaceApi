using Marketplace.Web.DataAccess.Entities;

namespace Marketplace.Web.Domain.Models.Categories
{
    public class CategoryDto
    {
        public Picture Icon { get; set; }
        public string Name { get; set; }
        public long? ParentCategoryId { get; set; }
    }
}
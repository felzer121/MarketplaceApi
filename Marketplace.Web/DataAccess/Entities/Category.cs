using System.Collections.Generic;

namespace Marketplace.Web.DataAccess.Entities
{
    public class Category : BaseEntity
    {
        public Picture Icon { get; set; }
        public long? IconId { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> SubCategories { get; set; }
        
        public List<Product> Products { get; set; }
    }
}
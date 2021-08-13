using System.Collections.Generic;

namespace Marketplace.Web.DataAccess.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public List<ApplicationUser> ApplicationUser { get; set; }
        public List<Product> Products { get; set; }
    }
}

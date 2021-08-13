using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Web.DataAccess.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; }
        public long ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Product> Products { get; set; }
    }
}

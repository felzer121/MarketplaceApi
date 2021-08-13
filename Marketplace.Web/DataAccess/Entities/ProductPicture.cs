using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Web.DataAccess.Entities
{
    public class ProductPicture : BaseEntity
    {
        public string File { get; set; }
        public string FullName { get; set; }
        public long ProductId { get; set; }
        public Product Product { get; set; }
    }
}

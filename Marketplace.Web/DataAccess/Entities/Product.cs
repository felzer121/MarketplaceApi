using System.Collections.Generic;

namespace Marketplace.Web.DataAccess.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public IReadOnlyList<ProductPicture> Pictures { get; set; }
        public Shop Shop { get; set; }
        public long ShopId { get; set; }
    }
}

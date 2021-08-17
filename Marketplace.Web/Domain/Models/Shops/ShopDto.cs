using Marketplace.Web.Domain.Models.Pictures;

namespace Marketplace.Web.Domain.Models.Shops
{
    public class ShopDto
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public PictureDto Logo { get; set; }
    }
}
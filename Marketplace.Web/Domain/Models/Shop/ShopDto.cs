namespace Marketplace.Web.Domain.Models.Shop
{
    public class ShopDto
    {
        public long UserId { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string PictureFile { get; set; }
        public string FullName { get; set; }
    }
}
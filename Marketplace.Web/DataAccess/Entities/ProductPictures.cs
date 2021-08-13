namespace Marketplace.Web.DataAccess.Entities
{
    public class ProductPictures : BaseEntity
    {
        public long ProductId { get; set; }
        public Product Product { get; set; }
        public long PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
using Marketplace.Web.Domain.Models.Pictures;

namespace Marketplace.Web.Domain.Services.Pictures
{
    public interface IPictureService
    {
        string SavePicture(PictureDto picture);
    }
}
using Marketplace.Web.Domain.Models.Pictures;
using Microsoft.Extensions.Configuration;

namespace Marketplace.Web.Domain.Services.Pictures
{
    public class PictureService : IPictureService
    {
        private readonly IConfiguration _configuration;

        public PictureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string SavePicture(PictureDto picture)
        {
            var path = _configuration["PicturePath"];

            return "";
        }
    }
}
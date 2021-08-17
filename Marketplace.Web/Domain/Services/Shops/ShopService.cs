using System;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.DataAccess.Entities;
using Marketplace.Web.Domain.Models.Pictures;
using Marketplace.Web.Domain.Models.Shops;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Domain.Services.Shops
{
    public class ShopService : IShopService
    {
        private readonly DataContext _context;

        public ShopService(DataContext context)
        {
            _context = context;
        }

        public async Task<long> Create(ShopDto shopDto)
        {
            if (shopDto == null)
            {
                throw new ArgumentException("Shop was null");
            }

            var entity = new Shop
            {
                Name = shopDto.Name
            };

            var result = await _context.Shops.AddAsync(entity);
            var shopId = result.Entity.Id;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == shopDto.UserId);
            user.ShopId = shopId;
            
            await _context.SaveChangesAsync();

            return shopId;
        }

        public ShopDto GetByUserId(long userId)
        {
            var shop = _context.Users
                .Include(x => x.Shop)
                .ThenInclude(x => x.Picture)
                .FirstOrDefault(x => x.Id == userId)?.Shop;

            if (shop == null)
            {
                throw new Exception("Shop not found");
            }

            return new ShopDto
            {
                Name = shop.Name,
                UserId = userId,
                Id = shop.Id,
                Logo = new PictureDto
                {
                    File = shop.Picture.File,
                    FileExtension = shop.Picture.FileExtension,
                    FileName = shop.Picture.FileName
                }
            };
        }

        public ShopDto GetByShopId(long shopId)
        {
            var shop = _context.Shops.Include(x => x.Picture).FirstOrDefault(x => x.Id == shopId);

            if (shop == null)
            {
                throw new Exception("Shop not found");
            }

            return new ShopDto
            {
                Id = shopId,
                Name = shop.Name,
                Logo = new PictureDto
                {
                    File = shop.Picture.File,
                    FileExtension = shop.Picture.FileExtension,
                    FileName = shop.Picture.FileName
                }
                //UserId = 0
            };
        }
    }
}
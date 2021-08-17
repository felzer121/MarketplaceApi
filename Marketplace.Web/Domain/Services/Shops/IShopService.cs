using System.Threading.Tasks;
using Marketplace.Web.Domain.Models.Shops;

namespace Marketplace.Web.Domain.Services.Shops
{
    public interface IShopService
    {
        Task<long> Create(ShopDto shop);
        ShopDto GetByUserId(long userId);
        ShopDto GetByShopId(long shopId);
    }
}
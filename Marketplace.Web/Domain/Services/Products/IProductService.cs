using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marketplace.Web.Domain.Services.Products
{
    public interface IProductService
    {
        IReadOnlyList<DataAccess.Entities.Product> GetAll(int take = 10, int skip = 0);
        Task<long> Create(DataAccess.Entities.Product product);
        Task Update(DataAccess.Entities.Product product);
        Task Delete(DataAccess.Entities.Product product);
    }
}

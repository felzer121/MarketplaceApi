using Marketplace.Web.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Web.Domain.Services.Products
{
    public interface IProductService
    {
        IReadOnlyList<Product> GetAll(int take = 10, int skip = 0);
        Task<long> Create(Product product);
        Task Update(Product product);
        Task Delete(Product product);
    }
}

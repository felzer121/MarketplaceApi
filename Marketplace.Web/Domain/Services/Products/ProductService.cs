using Marketplace.Web.DataAccess;
using Marketplace.Web.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Marketplace.Web.Domain.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<long> Create(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException("Product was null");
            }

            var entity = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return entity.Entity.Id;
        }

        public async Task Delete(Product product)
        {
            if(product?.Id == null)
            {
                throw new ArgumentNullException("Product was null");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public IReadOnlyList<Product> GetAll(int take = 10, int skip = 0)
        {
            var result = _context.Products.Take(take).Skip(skip).ToList();

            return result;
        }

        public async Task Update(Product product)
        {
            if (product?.Id == null)
            {
                throw new ArgumentNullException("Product was null");
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Web.DataAccess.Entities;
using Marketplace.Web.Domain.Models.Categories;

namespace Marketplace.Web.Domain.Services.Categories
{
    public interface ICategoryService
    {
        Task Create(CategoryDto category);
        List<Category> GetAll();
    }
}
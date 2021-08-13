using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Web.DataAccess
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Web.DataAccess
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Picture> ProductPictures { get; set; }
        
        public DbSet<Shop> Shops { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

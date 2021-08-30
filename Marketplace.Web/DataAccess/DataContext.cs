using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.DataAccess
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Picture> ProductPictures { get; set; }
        public DbSet<Shop> Shops { get; set; }
        
        /// <summary>
        /// Акции
        /// </summary>
        public DbSet<Sales> Sales { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x=> x.Name);
                entity.HasOne(x=> x.Parent)
                    .WithMany(x=> x.SubCategories)
                    .HasForeignKey(x=> x.ParentId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

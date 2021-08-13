using Marketplace.Web.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Web.DataAccess
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductPicture> ProductPictures { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}

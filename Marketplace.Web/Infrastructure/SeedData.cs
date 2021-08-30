using System.Threading.Tasks;
using Marketplace.Web.DataAccess;
using Marketplace.Web.DataAccess.Entities;
using Marketplace.Web.Domain.Services.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Web.Infrastructure
{
    public class SeedData
    {
        private readonly DataContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(DataContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task AddCategories()
        {
            var picture = new Picture();
            await _context.Categories.AddAsync(new Category
            {
                Icon = picture,
                Name = "",
                
            });
        }

        public async Task AddUsers()
        {
            var admin = new ApplicationUser
            {
                Email = "admin@marketplace.com",
                Patronymic = "Admin",
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "admin"
            };

            await _userManager.CreateAsync(admin, "S3cur1ty");
            var adminUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == admin.Email); 

            await _userManager.AddToRoleAsync(adminUser, AppRole.Admin);

            var seller = new ApplicationUser
            {
                Email = "seller@marketplace.com",
                Patronymic = "Seller",
                FirstName = "Seller",
                LastName = "Seller",
                UserName = "seller"
            };
            
            await _userManager.CreateAsync(seller, "S3cur1ty");
            var sellerUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == admin.Email); 

            await _userManager.AddToRoleAsync(sellerUser, AppRole.Seller);
        }
    }

    public class CategoryModel
    {
        
    }
}
using Microsoft.AspNetCore.Identity;

namespace Marketplace.Web.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Shop Shop { get; set; }
        public long ShopId { get; set; }
    }
}

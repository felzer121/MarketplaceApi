using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.Web.DataAccess.Entities
{
    public class ApplicationUser : IdentityUser<long>
    {
        public Shop Shop { get; set; }
        public long ShopId { get; set; }
    }
}

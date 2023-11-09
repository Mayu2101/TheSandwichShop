using TheSandwichShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSandwichShop.Factory
{
    public class AppUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<AppUser, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        {
        }

    }
}

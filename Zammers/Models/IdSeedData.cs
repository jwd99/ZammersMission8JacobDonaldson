using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zammers.Models
{
    public static class IdSeedData
    {
        private const string adminUser = "Admin";
        //Password for assignment
        private const string adminPass = "413ExtraYeetPeriod(t)!";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            IdentityContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<IdentityContext>();
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if(user==null)
            {
                user = new IdentityUser(adminUser);
                user.Email = "mycoolemail@senate.net";
                user.PhoneNumber = "777-7777";
                await userManager.CreateAsync(user, adminPass);
            }

        }

    }
}

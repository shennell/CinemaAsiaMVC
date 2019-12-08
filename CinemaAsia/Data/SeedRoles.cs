using CinemaAsia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAsia.Data
{
    public static class SeedRoles
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            IdentityResult roleResult;

            var checkRole = await RoleManager.RoleExistsAsync("Administrator");
            if(!checkRole)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            ApplicationUser user = await UserManager.FindByEmailAsync("admin@email.com");
            await UserManager.AddToRoleAsync(user, "Administrator");

        }
    }
}

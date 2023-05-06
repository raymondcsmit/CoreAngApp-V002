using Microsoft.AspNetCore.Identity;
using SecurityApp.Domain;
using SecurityApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    public static class DbInitializer
    {
        public static async Task SeedData(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            var roles = new string[] { "SuperAdmin", "Admin", "SuperUser", "User", "Referal", "Guest" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new ApplicationRole { Name = role, SetupCode = "S00001" });
                }
            }

            var users = new[]
            {
            new { Username = "waqar1@yahoo.com", Email = "waqar1@yahoo.com", Roles = new[] { "SuperAdmin", "Admin" }, Password = "Admin@123" },
            new { Username = "waqar2@yahoo.com", Email = "waqar2@yahoo.com", Roles = new[] { "Admin" }, Password = "Admin@123" },
            new { Username = "waqar3@yahoo.com", Email = "waqar3@yahoo.com", Roles = new[] { "SuperUser" }, Password = "Admin@123" },
            new { Username = "waqar4@yahoo.com", Email = "waqar4@yahoo.com", Roles = new[] { "User" }, Password = "Admin@123" },
            new { Username = "waqar5@yahoo.com", Email = "waqar5@yahoo.com", Roles = new[] { "Referal" }, Password = "Admin@123" },
            new { Username = "waqar6@yahoo.com", Email = "waqar6@yahoo.com", Roles = new[] { "Guest" }, Password = "Admin@123" },
            new { Username = "waqar7@yahoo.com", Email = "waqar7@yahoo.com", Roles = new[] { "SuperAdmin", "Admin", "User" }, Password = "Admin@123" },
        };

            foreach (var user in users)
            {
                if (await userManager.FindByNameAsync(user.Username) == null)
                {
                    var newUser = new ApplicationUser { UserName = user.Username, Email = user.Email };
                    var result = await userManager.CreateAsync(newUser, user.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRolesAsync(newUser, user.Roles);
                    }
                }
            }
        }
    }

}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SigmaSharp.Stern.Web.Models.Authentication;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SigmaSharp.Stern.Web.Persistance
{
    static class DataSeeder
    {
        public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
        {
            var serviceProvider = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope().ServiceProvider;
            var context = serviceProvider.GetService<CoreDbContext>();
            var logger = serviceProvider.GetService<ILogger<CoreDbContext>>();
            await context.Database.MigrateAsync();
            await InitializeUsers(serviceProvider, context, logger);
        }

        private static async Task InitializeUsers(IServiceProvider serviceProvider, CoreDbContext context, ILogger logger)
        {
            string[] roles = new string[] { "SuperAdmin", "Admin", "User" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole()
                    {
                        Name = role,
                        NormalizedName = role.ToUpper()
                    });
                }
            }

            var user = new ApplicationUser
            {
                FirstName = "Super",
                LastName = "Admin",
                Email = "admin@stern.com",
                NormalizedEmail = "ADMIN@STERN.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "admin");
                user.PasswordHash = hashed;

                var userStore = new UserStore<ApplicationUser>(context);
                await userStore.CreateAsync(user);

                logger.LogInformation("Created initial admin user");
            }

            await AssignRoles(serviceProvider, user.Email, roles);

            await context.SaveChangesAsync();
        }

        private static async Task<IdentityResult> AssignRoles(IServiceProvider services, string email, string[] roles)
        {
            UserManager<ApplicationUser> _userManager = services.GetService<UserManager<ApplicationUser>>();
            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRolesAsync(user, roles);

            return result;
        }
    }
}

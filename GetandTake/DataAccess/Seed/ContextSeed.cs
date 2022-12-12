using Microsoft.AspNetCore.Identity;
using GetandTake.Core.Models.Account;

namespace GetandTake.DataAccess.Seed;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(Role.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Role.User.ToString()));
    }

    public static async Task SeedAdminAsync(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var defaultUser = new IdentityUser
        {
            UserName = "admin",
            Email = "admin@admin.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "Admin123.");
                await userManager.AddToRoleAsync(defaultUser, Role.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, Role.User.ToString());
            }

        }
    }
}

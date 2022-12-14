using GetandTake.DataAccess.Seed;
using GetandTake.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace GetandTake.Startup.Configuration;

public static class SeedDataExtensions
{
    public static async void ConfigureSeedData(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var context = services.GetRequiredService<NorthwindDbContext>();
                var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await ContextSeed.SeedRolesAsync(roleManager);
                await ContextSeed.SeedAdminAsync(userManager, roleManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occurred seeding the DB.");
            }
        }
    }
}
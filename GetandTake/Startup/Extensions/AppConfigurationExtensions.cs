using GetandTake.Configuration.Extensions;
using GetandTake.DataAccess.Seed;
using GetandTake.DataAccess;
using GetandTake.Middlewares;
using Microsoft.AspNetCore.Identity;

namespace GetandTake.Startup.Extensions;

public static class AppConfigurationExtensions
{
    public static async Task ConfigureAsync(this WebApplication app)
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

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseCors(x => x
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.ExceptionHandler();

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.MapRazorPages();

        app.UseResponseCaching();

        app.UseResponseCompression();

        app.UseWhen(context => context.Request.Path.Value.Contains("/Categories/Images"), appBuilder =>
        {
            appBuilder.UseMiddleware<CachingMiddleware>();
        });

        app.MapControllers();
    }
}
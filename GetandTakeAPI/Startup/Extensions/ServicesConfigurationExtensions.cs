using GetandTake.Configuration.Extensions;
using GetandTake.Configuration.Settings;
using GetandTake.Core.DependencyResolvers;
using GetandTake.Core.Extensions;
using GetandTake.Core.Utilities.IoC;
using GetandTake.DataAccess;
using GetandTakeAPI.Startup.Configuration;
using Microsoft.AspNetCore.Identity;

namespace GetandTakeAPI.Startup.Extensions;

public static class ServicesConfigurationExtensions
{
    public static void Configure(this IServiceCollection services, AppSettings appSettings)
    {
        services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.SignIn.RequireConfirmedAccount = true;

            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        })
            .AddEntityFrameworkStores<NorthwindDbContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole>();

        services.AddDependencyResolvers(new ICoreModule[]
        {
            new CoreModule()
        });

        const int MaximumBodySizeValue = 1024;
        services.AddResponseCaching(options =>
        {
            options.MaximumBodySize = MaximumBodySizeValue;
            options.UseCaseSensitivePaths = true;
        });

        services.AddCors(policy =>
             policy.AddDefaultPolicy(builder =>
                builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()));

        services.RegisterServices(appSettings);

        services.RegisterDatabase(appSettings);

        services.AddEndpointsApiExplorer();

        services.RegisterAutomapper();

        services.RegisterControllers();

        services.RegisterSwagger();
    }
}
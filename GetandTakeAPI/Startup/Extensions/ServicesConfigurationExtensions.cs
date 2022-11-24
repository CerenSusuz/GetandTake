using GetandTake.Configuration.Extensions;
using GetandTake.Configuration.Settings;
using GetandTake.Core.DependencyResolvers;
using GetandTake.Core.Extensions;
using GetandTake.Core.Utilities.IoC;
using GetandTakeAPI.Startup.Configuration;

namespace GetandTakeAPI.Startup.Extensions;

public static class ServicesConfigurationExtensions
{
    public static void Configure(this IServiceCollection services, AppSettings appSettings)
    {
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
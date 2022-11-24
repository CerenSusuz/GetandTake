using System.Text.Json.Serialization;

namespace GetandTakeAPI.Startup.Configuration;

public static class ControllersExtensions
{
    public static void RegisterControllers(this IServiceCollection services)
    {
        services.AddControllers();
    }
}
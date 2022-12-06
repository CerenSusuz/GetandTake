using GetandTake.Configuration.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;

namespace GetandTake.Configuration.Extensions;

public static class AzureAdExtensions
{
    public static void RegisterAzure(
       this IServiceCollection services,
       IConfiguration configuration,
       AppSettings appSettings)
    {
        services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
            .AddAzureAD(options =>
            {
                configuration.Bind(nameof(appSettings.AzureAdSettings), options);
            });
    }
}
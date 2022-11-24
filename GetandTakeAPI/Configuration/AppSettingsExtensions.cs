using GetandTake.Configuration.Settings;
using GetandTakeAPI.ApplicationSettings;

namespace GetandTakeAPI.Configuration;

public static class AppSettingsExtensions
{
    public static AppSettings ReadAppSettings(this IConfiguration configuration)
    {
        var databaseSettings = configuration
            .GetSection(nameof(AppSettings.Database))
            .Get<DatabaseSettings>();
        var productSettings = configuration
            .GetSection(nameof(AppSettings.Products))
            .Get<ProductsSettings>();
        var hostSettings = configuration
            .GetSection(nameof(AppSettings.Host))
            .Get<HostSettings>();
        var logFilterSettings = configuration
            .GetSection(nameof(AppSettings.LoggingParameters))
            .Get<LogFilterSettings>();

        var appSettings = new AppSettings
        {
            Database = databaseSettings,
            Products = productSettings,
            Host = hostSettings,
            LoggingParameters = logFilterSettings
        };

        return appSettings;
    }
}
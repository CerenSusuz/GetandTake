using GetandTake.Configuration.Settings;

namespace GetandTake.Startup.Configuration;

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
        
        var githubSettings = configuration
            .GetSection(nameof(AppSettings.GithubParameters))
            .Get<GithubSettings>();

        var emailConfiguration = configuration
            .GetSection(nameof(AppSettings.EmailConfiguration))
            .Get<EmailSettings>();

        var appSettings = new AppSettings
        {
            Database = databaseSettings,
            Products = productSettings,
            Host = hostSettings,
            LoggingParameters = logFilterSettings,
            GithubParameters = githubSettings,
            EmailConfiguration = emailConfiguration
        };

        return appSettings;
    }
}
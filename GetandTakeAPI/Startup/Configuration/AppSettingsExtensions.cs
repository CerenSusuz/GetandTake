using GetandTake.Configuration.Settings;

namespace GetandTakeAPI.Startup.Configuration;

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
            .GetSection(nameof(AppSettings.GithubSettings))
            .Get<GithubSettings>();

        var emailConfiguration = configuration
            .GetSection(nameof(AppSettings.EmailSettings))
            .Get<EmailSettings>();

        var azureAdSettings = configuration
           .GetSection(nameof(AzureAdSettings))
           .Get<AzureAdSettings>();

        var appSettings = new AppSettings
        {
            Database = databaseSettings,
            Products = productSettings,
            Host = hostSettings,
            LoggingParameters = logFilterSettings,
            GithubSettings = githubSettings,
            EmailSettings = emailConfiguration,
            AzureAdSettings = azureAdSettings,
        };

        return appSettings;
    }
}
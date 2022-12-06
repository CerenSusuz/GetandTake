using GetandTake.Configuration.Settings;

namespace GetandTake.Configuration.Extensions;

public static class GithubExtensions
{
    public static void RegisterGithub(
        this IServiceCollection services,
        AppSettings appSettings)
    {
        services.AddAuthentication()
            .AddGitHub(options =>
            {
                options.ClientId = appSettings.GithubSettings.ClientId;
                options.ClientSecret = appSettings.GithubSettings.ClientSecret;
                options.CallbackPath = appSettings.GithubSettings.CallbackPath;
            });
    }
}
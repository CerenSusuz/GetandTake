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
                options.ClientId = appSettings.GithubParameters.ClientId;
                options.ClientSecret = appSettings.GithubParameters.ClientSecret;
                options.CallbackPath = appSettings.GithubParameters.CallbackPath;
            });
    }
}
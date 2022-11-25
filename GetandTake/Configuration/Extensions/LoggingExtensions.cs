namespace GetandTake.Configuration.Extensions;

public static class LoggingExtensions
{
    public static void RegisterLogging(this WebApplicationBuilder builder)
    {
        builder.Host.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
        });
    }
}
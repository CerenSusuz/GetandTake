using GetandTake.Configuration.Settings;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetandTake.Core.Filters;

[AttributeUsage(AttributeTargets.All)]
public class LogActionFilterAttribute : Attribute, IAsyncPageFilter
{
    private readonly ILogger<LogActionFilterAttribute> _logger;
    private readonly AppSettings _appSettings;

    public LogActionFilterAttribute(
        ILogger<LogActionFilterAttribute> logger,
        AppSettings appSettings)
    {
        _logger = logger;
        _appSettings = appSettings;
    }

    public async Task OnPageHandlerExecutionAsync(
        PageHandlerExecutingContext context,
        PageHandlerExecutionDelegate next)
    {
        var page = context.RouteData.Values["page"];

        if (_appSettings.LoggingParameters.IsLogFilterActive)
        {
            _logger.LogInformation($"The page is {page} {nameof(OnPageHandlerExecutionAsync)}");
        }

        await next.Invoke();
    }

    public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        var page = context.RouteData.Values["page"];
        _logger.LogInformation($"The page is {page} {nameof(OnPageHandlerSelectionAsync)}");
        await Task.CompletedTask;
    }
}
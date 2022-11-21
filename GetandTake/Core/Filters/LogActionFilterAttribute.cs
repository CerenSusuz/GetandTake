using GetandTake.Configuration.Settings;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetandTake.Core.Filters;

public class LogActionFilterAttribute : ResultFilterAttribute, IAsyncPageFilter
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

        if (_appSettings.LogFilter.IsLogFilterActive)
        {
            _logger.LogInformation(nameof(context), page);
        }
        await next.Invoke();
    }

    public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        _logger.LogInformation(nameof(context));
        await Task.CompletedTask;
    }
}
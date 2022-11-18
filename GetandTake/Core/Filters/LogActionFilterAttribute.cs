using Microsoft.AspNetCore.Mvc.Filters;

namespace GetandTake.Core.Filters;

public class LogActionFilterAttribute : ActionFilterAttribute
{
    private readonly ILogger<LogActionFilterAttribute> _logger;

    public LogActionFilterAttribute(ILogger<LogActionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        _logger.LogInformation($"Log action: {0} {1}",nameof(OnActionExecuting), filterContext.RouteData.Values["page"]);
    }

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        _logger.LogInformation($"Log action: {nameof(OnActionExecuted)}{filterContext.RouteData.Values["page"]}");
    }

    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        _logger.LogInformation($"Log action: {nameof(OnResultExecuting)}{filterContext.RouteData.Values["page"]}");
    }

    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        _logger.LogInformation($"Log action: {nameof(OnResultExecuted)}{filterContext.RouteData.Values["page"]}");
    }
}
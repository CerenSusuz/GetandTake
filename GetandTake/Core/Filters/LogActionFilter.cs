using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace GetandTake.Core.Filters;

public class LogActionFilter : ActionFilterAttribute

{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        Log("OnActionExecuting", filterContext.RouteData);
    }

    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        Log("OnActionExecuted", filterContext.RouteData);
    }

    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
        Log("OnResultExecuting", filterContext.RouteData);
    }

    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
        Log("OnResultExecuted", filterContext.RouteData);
    }

    private void Log(string methodName, RouteData routeData)
    {
        var pageName = routeData.Values["page"];
        var message = string.Format("{0} page:{1}", methodName, pageName);
        Debug.WriteLine(message, "Action Filter Log");
    }
}
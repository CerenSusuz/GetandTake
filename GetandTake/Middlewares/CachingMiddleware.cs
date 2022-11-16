using GetandTake.Core.Aspects.Caching;
using Microsoft.Net.Http.Headers;

namespace GetandTake.Middlewares;

public class CachingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public CachingMiddleware(
        RequestDelegate next,
        ILoggerFactory logFactory)
    {
        _next = next;
        _logger = logFactory.CreateLogger("CachingMiddleware");
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        httpContext.Response.GetTypedHeaders().CacheControl =
            new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromSeconds(60)
            };
        _logger.LogInformation("Caching Middleware executing..");

        await _next(httpContext);
    }
}

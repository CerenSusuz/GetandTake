using GetandTake.Core.Aspects.Caching;

namespace GetandTake.Middlewares;

public class CachingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly CacheAspect _cacheAspect;
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
        _logger.LogInformation("Caching Middleware executing..");

        await _next(httpContext);
    }
}

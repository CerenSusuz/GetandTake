using GetandTake.Core.Aspects.Caching;
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.Core.Utilities.IoC;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.Net.Http.Headers;

namespace GetandTake.Core.Middlewares;

public class ImageCachingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ICacheService _cacheService;
    private readonly CacheAspect _cacheAspect;
    private readonly ILogger _logger;

    public ImageCachingMiddleware(
        RequestDelegate next, 
        ILoggerFactory logFactory,
        ICacheService cacheService)
    {
        _next = next;
        _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
        _logger = logFactory.CreateLogger("MyCustomMiddleware");
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        _logger.LogInformation("ImageCachingMiddleware executing..");
        httpContext.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue()
                {
                    MaxAge = TimeSpan.FromMinutes(_cacheAspect._duration),
                    Private = _cacheAspect.Location == "Client",
                    Public = _cacheAspect.Location == "Any"
                };

        var responseCachingFeature = httpContext.Features.Get<IResponseCachingFeature>();

        if (responseCachingFeature != null)
        {
            responseCachingFeature.VaryByQueryKeys = new[] { "Id" };
        }

        await _next(httpContext);
    }
}

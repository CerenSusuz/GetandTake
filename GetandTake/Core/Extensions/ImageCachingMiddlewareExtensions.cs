using GetandTake.Middlewares;

namespace GetandTake.Core.Extensions;

public static class ImageCachingMiddlewareExtensions
{
    public static IApplicationBuilder UseMyCustomMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CachingMiddleware>();
    }
}

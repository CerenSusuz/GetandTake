namespace GetandTake.Middlewares;

public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public MyCustomMiddleware(RequestDelegate next, ILoggerFactory logFactory)
	{
        _next = next;
        _logger = logFactory.CreateLogger("MyMiddleware");
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {

        _logger.LogInformation("MyMiddleware executing..");

        await _next(httpContext); 
    }
}

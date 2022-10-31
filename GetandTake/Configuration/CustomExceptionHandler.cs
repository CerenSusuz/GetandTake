using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace GetandTake.Configuration;

public static class CustomExceptionHandler
{
    public static void ExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = Text.Plain;

                await context.Response.WriteAsync("An exception was thrown.");

                var exceptionHandlerPathFeature =
                    context.Features.Get<IExceptionHandlerPathFeature>();
                
                if (exceptionHandlerPathFeature == null)
                {
                    return;
                }

                if (exceptionHandlerPathFeature.Error is FileNotFoundException)
                {
                    await context.Response.WriteAsync(" The file was not found.");
                }

                if (exceptionHandlerPathFeature.Path == "/")
                {
                    await context.Response.WriteAsync(" Page: Home.");
                }
            });
        });
    }
}
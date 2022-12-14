using GetandTake.Configuration.Extensions;
using GetandTake.Middlewares;
using Microsoft.AspNetCore.HttpOverrides;

namespace GetandTake.Startup.Extensions;

public static class AppConfigurationExtensions
{
    public static void Configure(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseCors(x => x
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.ExceptionHandler();

        app.MapRazorPages();

        app.UseResponseCaching();

        app.UseWhen(context => context.Request.Path.Value.Contains("/Categories/Images"),
            appBuilder =>
        {
            appBuilder.UseMiddleware<CachingMiddleware>();
        });

        app.MapControllers();
    }
}
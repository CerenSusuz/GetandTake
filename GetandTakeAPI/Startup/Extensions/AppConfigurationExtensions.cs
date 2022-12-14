using GetandTake.Configuration.Extensions;
using GetandTake.Configuration.Settings;

namespace GetandTakeAPI.Startup.Extensions;

public static class AppConfigurationExtensions
{
    public static void Configure(this WebApplication app, AppSettings appSettings)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GetandTake v1"));
        }

        app.UseCors(policy => policy
            .SetIsOriginAllowed(_ => true)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.ExceptionHandler();

        app.UseResponseCaching();

        app.MapControllers();
    }
}
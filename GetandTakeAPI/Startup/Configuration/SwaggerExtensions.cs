using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GetandTakeAPI.Startup.Configuration;

public static class SwaggerExtensions
{
    public static void RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(swaggerGen =>
        {
            swaggerGen.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "GetandTake.API",
                Version = "v1",
                Description = "NET 6 Web API for managing GetandTake project",
                Contact = new OpenApiContact
                {
                    Name = "gerund",
                    Email = "ceren199704@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://getandtake.com/license")
                }
            });


            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

            swaggerGen.IncludeXmlComments(xmlPath);
        });
    }
}
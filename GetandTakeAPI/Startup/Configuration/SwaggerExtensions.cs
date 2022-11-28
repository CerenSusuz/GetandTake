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
                Description = "NET 6 Web API",
                Contact = new OpenApiContact
                {
                    Name = "gerund",
                    Email = "ceren199704@gmail.com"
                }
            });


            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            swaggerGen.IncludeXmlComments(xmlPath);
        });
    }
}
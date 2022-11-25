using GetandTake.Core.Filters;
using SmartBreadcrumbs.Extensions;
using System.Reflection;

namespace GetandTake.Startup.Configuration;

public static class PagesExtensions
{
    public static void RegisterControllers(this IServiceCollection services)
    {
        services
            .AddRazorPages()
            .AddMvcOptions(options =>
            {
                options.Filters.Add(typeof(LogActionFilterAttribute));
            })
            .AddRazorRuntimeCompilation();

        services.AddBreadcrumbs(Assembly.GetExecutingAssembly(), options =>
        {
            options.TagName = "nav";
            options.TagClasses = "";
            options.OlClasses = "breadcrumb";
            options.LiClasses = "breadcrumb-item";
            options.ActiveLiClasses = "breadcrumb-item active";
            options.SeparatorElement = "<li class=\"separator\">/</li>";
        });
    }
}
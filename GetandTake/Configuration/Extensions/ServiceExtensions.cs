using GetandTake.Business.Services.Abstract;
using GetandTake.Business.Services.Concrete;
using GetandTake.Configuration.Settings;
using GetandTake.Core.CrossCuttingConcerns.Caching.Microsoft;
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.DataAccess.Repositories.Concrete;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace GetandTake.Configuration.Extensions;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, AppSettings appSettings)
    {
        //AppSettings
        services.AddSingleton(appSettings);

        //Business Services
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ISupplierService, SupplierManager>();

        //Database Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        services.AddMemoryCache();
        services.AddSingleton<ICacheService, MemoryCacheManager>();

        services.AddScoped<IEmailSender, EmailSenderManager>();
    }
}
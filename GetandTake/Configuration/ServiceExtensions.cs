using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.DataAccess.Repositories.Concrete;
using GetandTake.Services.Abstract;
using GetandTake.Services.Concrete;

namespace GetandTake.Configuration;

public static class ServiceExtensions
{
    public static void RegisterServices(this IServiceCollection services, AppSettings appSettings)
    {
        //AppSettings
        services.AddSingleton(appSettings);

        //Business Services
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICategoryImageService, CategoryImageManager>();
        services.AddScoped<ISupplierService, SupplierManager>();
        
        //Database Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryImageRepository, CategoryImageRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
    }
}

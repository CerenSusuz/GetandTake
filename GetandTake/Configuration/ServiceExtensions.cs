using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.DataAccess.Repositories.Concrete;
using GetandTake.Services.Abstract;
using GetandTake.Services.Concrete;

namespace GetandTake.Configuration;

public static class ServiceExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IProductService, ProductManager>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}

﻿using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.DataAccess.Repositories.Concrete;
using GetandTake.Services.Abstract;
using GetandTake.Services.Concrete;

namespace GetandTake.Configuration;

public static class ServiceExtensions
{
    public static void RegisterServices(this WebApplicationBuilder builder, AppSettings appSettings)
    {
        //AppSettings
        builder.Services.AddSingleton(appSettings);

        //Business Services
        builder.Services.AddScoped<IProductService, ProductManager>();    
        builder.Services.AddScoped<ICategoryService, CategoryManager>();

        //Database Repositories
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    }
}
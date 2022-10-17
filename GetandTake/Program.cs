using AutoMapper;
using GetandTake.Configuration.Services;
using GetandTake.Core.DataAccess;
using GetandTake.DataAccess;
using GetandTake.DataAccess.Repositories.Abstract;
using GetandTake.DataAccess.Repositories.Concrete;
using GetandTake.Services.Abstracts;
using GetandTake.Services.AutoMapper;
using GetandTake.Services.Concretes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
DatabaseExtension.RegisterDatabase(builder);
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<,>));
builder.Services.AddSingleton(new MapperConfiguration(mapperConfig => 
                                                      mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

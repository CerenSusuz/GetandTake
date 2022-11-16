using AutoMapper;
using GetandTake.Business.Services.AutoMapper;
using GetandTake.Configuration;
using GetandTake.Core.DependencyResolvers;
using GetandTake.Core.Extensions;
using GetandTake.Core.Filters;
using GetandTake.Core.Utilities.IoC;
using GetandTake.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterLogging();
// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddMvcOptions(options =>
    {
        options.Filters.Add(new LogActionFilter());
    })
    .AddRazorRuntimeCompilation();

builder.Services.AddDependencyResolvers(new ICoreModule[]{
    new CoreModule()
});

builder.Services.AddSingleton(new MapperConfiguration(mapperConfig =>
                                                      mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());
builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 1024;
    options.UseCaseSensitivePaths = true;
});

var databaseSettings = builder.Configuration.GetSection(nameof(AppSettings.Database)).Get<DatabaseSettings>();
var productSettings = builder.Configuration.GetSection(nameof(AppSettings.Products)).Get<ProductsSettings>();

var appSettings = new AppSettings
{
    Database = databaseSettings,
    Products = productSettings
};

builder.Services.RegisterServices(appSettings);
builder.Services.RegisterDatabase(appSettings);

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.ExceptionHandler();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseResponseCaching();

app.UseWhen(context => context.Request.Path.Value.Contains("/Categories/Images"), appBuilder =>
{
    appBuilder.UseMiddleware<CachingMiddleware>();
});

app.MapRazorPages();

app.Run();


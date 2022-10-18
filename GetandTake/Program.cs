using AutoMapper;
using GetandTake.Configuration;
using GetandTake.Services.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddSingleton(new MapperConfiguration(mapperConfig =>
                                                      mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());

var databaseSettings = builder.Configuration.GetSection(nameof(AppSettings.Database)).Get<DatabaseSettings>();
var productSettings = builder.Configuration.GetSection(nameof(AppSettings.Products)).Get<ProductsSettings>();

var appSettings = new AppSettings
{
    Database = databaseSettings,
    Products = productSettings
};

ServiceExtensions.RegisterServices(builder, appSettings);
DatabaseExtensions.RegisterDatabase(builder, appSettings);

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


using AutoMapper;
using GetandTake.Configuration;
using GetandTake.Services.AutoMapper;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterLogging();
// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddRazorRuntimeCompilation()
    .AddMvcOptions(options =>
    {
        options.MaxModelValidationErrors = 50;
        options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
        _ => "The field is required.");
    });
builder.Services.AddSingleton(new MapperConfiguration(mapperConfig =>
                                                      mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());

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
}

app.ExceptionHandler();

app.UseStatusCodePages(async statusCodeContext =>
{
    statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

    await statusCodeContext.HttpContext.Response.WriteAsync(
        $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
});

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


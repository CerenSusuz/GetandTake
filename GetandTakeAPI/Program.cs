using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using GetandTake.Business.DependencyResolvers.Autofac;
using GetandTake.Business.Services.AutoMapper;
using GetandTake.Configuration.Extensions;
using GetandTake.Configuration.Settings;
using GetandTake.Core.DependencyResolvers;
using GetandTake.Core.Extensions;
using GetandTake.Core.Utilities.IoC;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDependencyResolvers(new ICoreModule[]{
    new CoreModule()
});

builder.Services.AddSingleton(new MapperConfiguration(mapperConfig =>
                                                      mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());
const int MaximumBodySizeValue = 1024;
builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = MaximumBodySizeValue;
    options.UseCaseSensitivePaths = true;
});

var databaseSettings = builder.Configuration
    .GetSection(nameof(AppSettings.Database))
    .Get<DatabaseSettings>();
var productSettings = builder.Configuration
    .GetSection(nameof(AppSettings.Products))
    .Get<ProductsSettings>();
var hostSettings = builder.Configuration
    .GetSection(nameof(AppSettings.Host))
    .Get<HostSettings>();
var logFilterSettings = builder.Configuration
    .GetSection(nameof(AppSettings.LoggingParameters))
    .Get<LogFilterSettings>();

var appSettings = new AppSettings
{
    Database = databaseSettings,
    Products = productSettings,
    Host = hostSettings,
    LoggingParameters = logFilterSettings
};

builder.Services.RegisterServices(appSettings);
builder.Services.RegisterDatabase(appSettings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGen =>
{
    swaggerGen.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GetandTake.API",
        Version = "v1",
        Description = "NET 6",
        Contact = new OpenApiContact
        {
            Name = "GetandTake API Project"
        }
    });
});

builder.Services.AddCors(policy =>
     policy.AddDefaultPolicy(builder =>
        builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .SetIsOriginAllowed(_ => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.ExceptionHandler();

app.UseResponseCaching();

app.MapControllers();

app.Run();
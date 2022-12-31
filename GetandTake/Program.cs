using GetandTake.Configuration.Extensions;
using GetandTake.Startup.Configuration;
using GetandTake.Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterLogging();

var appSettings = builder.Configuration.ReadAppSettings();
appSettings.Validate();

builder.Services.Configure(appSettings);
builder.Services.RegisterAzure(builder.Configuration, appSettings);

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
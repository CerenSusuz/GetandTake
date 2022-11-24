using GetandTake.Configuration.Extensions;
using GetandTake.Startup.Configuration;
using GetandTake.Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterLogging();

var appSettings = builder.Configuration.ReadAppSettings();
appSettings.Validate();

builder.Services.Configure(appSettings);

var app = builder.Build();

app.Configure(appSettings);

app.Run();
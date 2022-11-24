using GetandTake.Configuration.Extensions;
using GetandTakeAPI.Startup.Configuration;
using GetandTakeAPI.Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterLogging();

var appSettings = builder.Configuration.ReadAppSettings();
appSettings.Validate();

builder.Services.Configure(appSettings);

var app = builder.Build();

app.Configure(appSettings);

app.Run();
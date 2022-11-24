using GetandTakeAPI.Configuration;
using GetandTakeAPI.Startup.Extensions;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.ReadAppSettings();
appSettings.Validate();

builder.Services.Configure(appSettings);

var app = builder.Build();

app.Configure(appSettings);

app.Run();
using AutoMapper;
using GetandTake.Business.Services.AutoMapper;

namespace GetandTakeAPI.Startup.Configuration;

public static class AutomapperExtensions
{
    public static void RegisterAutomapper(this IServiceCollection services)
    {
        services.AddSingleton(new MapperConfiguration(mapperConfig =>
                                                     mapperConfig.AddProfile(new AutoMapperProfile())).CreateMapper());
    }
}
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.Core.CrossCuttingConcerns.Caching.Microsoft;
using GetandTake.Core.Utilities.IoC;

namespace GetandTake.Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection serviceCollection)
    {
        serviceCollection.AddMemoryCache();

        serviceCollection.AddSingleton<ICacheService, MemoryCacheManager>();
    }
}
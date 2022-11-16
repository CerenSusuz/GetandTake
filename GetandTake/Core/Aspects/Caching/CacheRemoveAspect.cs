using Castle.DynamicProxy;
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.Core.Utilities.Interceptors;
using GetandTake.Core.Utilities.IoC;

namespace GetandTake.Core.Aspects.Caching;

public class CacheRemoveAspect : MethodInterception
{
    private string _pattern;
    private ICacheService _cacheService;

    public CacheRemoveAspect(string pattern)
    {
        _pattern = pattern;
        _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
        _cacheService.RemoveByPattern(_pattern);
    }
}
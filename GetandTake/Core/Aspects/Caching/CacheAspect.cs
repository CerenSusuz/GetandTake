using Castle.DynamicProxy;
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.Core.Interceptors;
using GetandTake.Core.Utilities.IoC;

namespace GetandTake.Core.Aspects.Caching;

public class CacheAspect : MethodInterception
{
    private const int _defaultDuration = 60;
    private readonly ICacheService _cacheService;

    public readonly int _duration;

    public string Location { get; set; } = "Client";

    public CacheAspect()
    {
        _duration = _defaultDuration;
    }

    public CacheAspect(int duration)
    {
        _duration = duration;
        _cacheService = ServiceTool.ServiceProvider.GetService<ICacheService>();
    }

    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
        var arguments = invocation.Arguments.ToList();
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
        
        if (_cacheService.IsAdded(key))
        {
            invocation.ReturnValue = _cacheService.Get<string>(key);
            
            return;
        }

        invocation.Proceed();
        _cacheService.Add<object>(key, invocation.ReturnValue, _duration);
    }
}

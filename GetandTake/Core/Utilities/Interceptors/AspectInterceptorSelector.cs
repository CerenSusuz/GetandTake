﻿using Castle.DynamicProxy;
using System.Reflection;

namespace GetandTake.Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
            (inherit: true).ToList();
        var methodAttributes = type.GetMethod(method.Name)
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true);
        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(method => method.Priority).ToArray();
    }
}
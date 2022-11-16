using Autofac;
using AutoMapper;
using GetandTake.Core.CrossCuttingConcerns.Caching.Microsoft;
using GetandTake.Core.CrossCuttingConcerns.Caching;
using GetandTake.Services.Abstract;
using GetandTake.Services.Concrete;
using System.Reflection;
using Castle.DynamicProxy;
using GetandTake.Core.Interceptors;
using Module = Autofac.Module;
using Autofac.Extras.DynamicProxy;

namespace GetandTake.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();

        builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();

        builder.RegisterType<SupplierManager>().As<ISupplierService>().SingleInstance();

        builder.RegisterType<Mapper>().As<IMapper>().SingleInstance();

        builder.RegisterType<MemoryCacheManager>().As<ICacheService>().SingleInstance();

        var assembly = Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions
            { Selector = new AspectInterceptorSelector() })
            .SingleInstance();
    }
}

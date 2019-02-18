using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Domain.Contract.Ioc
{
    public enum LifeCycleType
    {
        Singleton = 0,
        Scoped = 1,
        Transient = 2

    }

    public interface IContainer
    {

        TService GetInstance<TService>() where TService : class;
      

        void Register<TService, TImplementation>(LifeCycleType lifestyle);
        void Register(Type service, Assembly assemblies, LifeCycleType lifestyle);
        void Register<TService>(Func<object> instanceCreator, LifeCycleType lifestyle);
        


        void AddAspCoreDependencyInjection(IServiceCollection services);
        void UseAspCoreDependencyInjection(IApplicationBuilder app);
        void RegisterMediateR(IList<Assembly> assemblies);




    }
}

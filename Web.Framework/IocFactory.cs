using System;
using System.Threading;
using Core.Domain.Contract.Ioc;
using Infrastructure.Ioc;

namespace Web.Framework
{
    public  class IocFactory
    {
        private static  IContainer _container;


        private static readonly Lazy<IocFactory> _instance =new Lazy<IocFactory>(() => new IocFactory(), LazyThreadSafetyMode.ExecutionAndPublication);


        public static IocFactory Instance => _instance.Value;


        public static IContainer Container()
        {
            if (_container != null) return _container;
            var simpleInjectorContainer = new SimpleInjectorContainer();
            _container = simpleInjectorContainer;

            return _container;

        }

      


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Core.Domain._Shared.CQRS.AOP;
using Core.Domain._Shared.Ioc;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;

namespace Infrastructure.Ioc
{
    public class SimpleInjectorContainer: IContainer
    {

        private readonly Container _container;


        public SimpleInjectorContainer()
        {
            _container = new Container();
            
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Options.DefaultLifestyle = Lifestyle.Scoped;
            _container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();

        }

        public TService GetInstance<TService>() where TService : class
        {
            
            return _container.GetInstance<TService>();
        }
      


        public void Register<TService, TImplementation>(LifeCycleType lifestyle)
        {
            switch (lifestyle)
            {
                case LifeCycleType.Singleton:
                    _container.Register(typeof(TService), typeof(TImplementation), Lifestyle.Singleton);
                    break;
                case LifeCycleType.Scoped:
                    _container.Register(typeof(TService), typeof(TImplementation), Lifestyle.Scoped);
                    break;
                case LifeCycleType.Transient:
                    _container.Register(typeof(TService), typeof(TImplementation), Lifestyle.Transient);
                    break;
            }
        }

        public void Register(Type service, Assembly assemblies, LifeCycleType lifestyle)
        {
            switch (lifestyle)
            {
                case LifeCycleType.Singleton:
                    _container.Register(service, assemblies, Lifestyle.Singleton);
                    break;
                case LifeCycleType.Scoped:
                    _container.Register(service, assemblies, Lifestyle.Scoped);
                    break;
                case LifeCycleType.Transient:
                   _container.Register(service,assemblies,Lifestyle.Transient);
                    break;
            }
           
        }

        public void Register<TService>(Func<object> instanceCreator, LifeCycleType lifestyle)
        {
            switch (lifestyle)
            {
                case LifeCycleType.Singleton:
                    _container.Register(typeof(TService), instanceCreator, Lifestyle.Singleton);
                    break;
                case LifeCycleType.Scoped:
                    _container.Register(typeof(TService), instanceCreator, Lifestyle.Scoped);
                    break;
                case LifeCycleType.Transient:
                    _container.Register(typeof(TService), instanceCreator, Lifestyle.Singleton);
                    
                    break;
            }
        }

      


        public void AddAspCoreDependencyInjection(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(_container));



            // Enables Injection into PageModel
            services.AddSingleton<IPageModelActivatorProvider>(new SimpleInjectorPageModelActivatorProvider(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);




        }

        public void UseAspCoreDependencyInjection(IApplicationBuilder app)
        {
            _container.RegisterMvcControllers(app);
            _container.RegisterMvcViewComponents(app);

            _container.AutoCrossWireAspNetComponents(app);
        }

        public void RegisterMediateR(IList<Assembly> assemblies)
        {
            _container.RegisterSingleton<IMediator, Mediator>();
            _container.Register(typeof(IRequestHandler<,>), assemblies);

            var notificationHandlerTypes = _container.GetTypesToRegister(typeof(INotificationHandler<>), assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });
            _container.Collection.Register(typeof(INotificationHandler<>), notificationHandlerTypes);


            var writer = new WrappingWriter(Console.Out);
            _container.Register(() => (TextWriter)writer, Lifestyle.Singleton);

            //Pipeline
            _container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
                typeof(GenericPipelineBehavior<,>)
            });

            _container.Collection.Register(typeof(IRequestPreProcessor<>), new[] { typeof(GenericRequestPreProcessor<>) });
            _container.Collection.Register(typeof(IRequestPostProcessor<,>), new[] { typeof(GenericRequestPostProcessor<,>), typeof(ConstrainedRequestPostProcessor<,>) });

            _container.Register(() => new ServiceFactory(_container.GetInstance), Lifestyle.Singleton);


        }




    }
}

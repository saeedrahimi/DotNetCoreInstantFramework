using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Domain.Contract.Services.Application.Identity;
using Core.Domain.Identity.Repository;
using Core.Domain.Identity.Services;
using Core.Domain._Shared.Data;
using Core.Domain._Shared.Data.Repository;
using Core.Domain._Shared.Ioc;
using Core.Domain._Shared.Logger;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Infrastructure.Data.Repository.Identity;
using Infrastructure.Logging;
using Infrastructure.Logging.Serilog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Application.Identity;
using Web.Framework;
using SimpleInjector;


namespace WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var conStr = Configuration["ConnectionStrings:main_server"];
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(conStr)
                        .UseLazyLoadingProxies());
            services.AddScoped(typeof(ILogger<>), typeof(SerilogLogger<>));
            IocFactory.Container().AddAspCoreDependencyInjection(services);
            var serviceProvider = services.BuildServiceProvider();
            InitializeContainer(serviceProvider);
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            IocFactory.Container().UseAspCoreDependencyInjection(app);
            app.UseMvc();

        }

        private void InitializeContainer(ServiceProvider serviceProvider)
        {
                        
            IocFactory.Container().Register(typeof(IEntityValidator<>),typeof(BaseEntityValidator<>).Assembly,LifeCycleType.Scoped);
            IocFactory.Container().Register<IUnitofWork, UnitOfWork>(LifeCycleType.Scoped);
            IocFactory.Container().Register<IUserRepository, UserRepository>(LifeCycleType.Scoped);
            
            
            IocFactory.Container().RegisterMediateR(new List<Assembly>()
            {
                AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(w => w.GetName().Name == "Core.Domain")
            });
            
            
            IocFactory.Container().Register<IIdentityService>(() => 
                    ServiceProxy<IIdentityService>.Create(
                        IocFactory.Container().GetInstance<IdentityService>(), 
                        serviceProvider.GetRequiredService<ILogger<IIdentityService>>()),
                LifeCycleType.Scoped);

        }

    }
}


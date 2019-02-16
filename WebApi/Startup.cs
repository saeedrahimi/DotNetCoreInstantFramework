
using Core.Contract.Data;
using Core.Contract.Data.Repository;
using Core.Contract.Data.Repository.Identity.User;
using Core.Contract.Ioc;
using Core.Contract.Logger;
using Core.Contract.Services.Application.Identity;
using Infrastructure.Data.EF;
using Infrastructure.Data.EF.Repository;
using Infrastructure.Data.EF.Repository.Identity;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Application.Identity;
using Web.Framework;


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
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("test"));
            IocFactory.Container().AddAspCoreDependencyInjection(services);
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            InitializeContainer();
            IocFactory.Container().UseAspCoreDependencyInjection(app);
            app.UseMvc();

        }

        private void InitializeContainer()
        {
                        
            IocFactory.Container().Register(typeof(IEntityValidator<>),typeof(BaseEntityValidator<>).Assembly,LifeCycleType.Scoped);
            
            IocFactory.Container().Register<IUnitofWork, UnitOfWork>(LifeCycleType.Scoped);
            IocFactory.Container().Register<IUserRepository, UserRepository>(LifeCycleType.Scoped);
           
            IocFactory.Container().Register<ILogger, ConsoleLogger>(LifeCycleType.Singleton);
            IocFactory.Container().Register<IIdentityService>(() => ServiceProxy<IIdentityService>.Create(IocFactory.Container().GetInstance<IdentityService>(), IocFactory.Container().GetInstance<ILogger>()), LifeCycleType.Scoped);


            

        }

    }
}


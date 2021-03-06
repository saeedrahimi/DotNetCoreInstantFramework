using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using Core.Domain.Identity.Repository;
using Core.Domain.Identity.Services;
using Core.Domain._Shared.Data;
using Core.Domain._Shared.Data.Repository;
using Core.Domain._Shared.Ioc;
using Core.Domain._Shared.Logger;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Infrastructure.Data.Repository.Identity;
using Infrastructure.Logging.Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Application.Identity;
using Web.Framework;
using WebPages.Authentication;


namespace WebPages
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

       
        
        public void ConfigureServices(IServiceCollection services)
        {

  
            services
                .AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var conStr = Configuration["ConnectionStrings:main_server"];
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(conStr)
                    .UseLazyLoadingProxies());
            
            services.AddScoped(typeof(ILogger<>), typeof(SerilogLogger<>));

            services.AddAuthentication(cfg =>
            {
                cfg.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                cfg.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                

            }).AddCookie(cfg =>
            {
                cfg.LogoutPath = "/account/login";
                //cfg.EventsType = typeof(CookieEventsHandler);
                //cfg.SlidingExpiration = false;
                cfg.LogoutPath = "/account/logout";
                //cfg.Cookie.HttpOnly = true;
              


            }).AddGoogle( cfg =>
            {
                cfg.ClientId = "119153056824-60idpbsugq2gkn5b703q4a5h2fc124c8.apps.googleusercontent.com";
                cfg.ClientSecret = "rj1cYibrjwRBfsPp5QzOh20_";
                cfg.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                

            });
               
            services.AddScoped(typeof(CookieEventsHandler), x => new CookieEventsHandler());


            //optimize
            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });


            IocFactory.Container().AddAspCoreDependencyInjection(services);
            var serviceProvider = services.BuildServiceProvider();
            InitializeContainer(serviceProvider);

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            IocFactory.Container().UseAspCoreDependencyInjection(app);
            app.UseMvc();
            
            
        }

        private void InitializeContainer(ServiceProvider serviceProvider)
        {

        
            IocFactory.Container().Register(typeof(IEntityValidator<>), typeof(BaseEntityValidator<>).Assembly, LifeCycleType.Scoped);
            IocFactory.Container().Register<IUnitofWork, UnitOfWork>(LifeCycleType.Scoped);
            IocFactory.Container().Register<IUserRepository, UserRepository>(LifeCycleType.Scoped); 
            IocFactory.Container().Register(typeof(ILogger<>), typeof(ILogger<>).Assembly,LifeCycleType.Scoped );
           
            
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

using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Data.EF;
using Infrastructure.Data.EF.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Framework
{
    public static class Extension
    {

        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                DbInitializer.Seed(context);
            }
            return host;
        }



    }
}

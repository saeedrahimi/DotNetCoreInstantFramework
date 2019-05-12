
using System;
using Core.Domain._Shared.Logger;
using Infrastructure.Data;
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
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    DbInitializer.Seed(context);
                }
                catch (Exception ex)
                {
                    logger.Fatal(ex, "An error occurred while migrating the database.");
                    throw;
                }
            }
            return host;
        }



    }
}

using System;
using Microsoft.Extensions.Configuration;

namespace Framework.Config
{
    public static class SharedConfigValueProvider
    {
        public static readonly IConfigurationRoot Configuration;

        static SharedConfigValueProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.AppContext.BaseDirectory)
                .AddJsonFile("appsettings.shared.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.shared.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public static string Get(string name)
        {
            return Configuration[name];
        }
    }
}

﻿using System;
using System.IO;
using Framework.Config;
using Infrastructure.Logging.Serilog;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Web.Framework;

namespace WebPages
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));

            return WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddConfiguration(SharedConfigValueProvider.Configuration);// Load shared settings from Framework.Common (settings could be override from the calling assembly appsetting.json)
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);
                    config.AddEnvironmentVariables();
                    
                })
                .UseStartup<Startup>()
                .UseSerilogCustomized()
                .Build()
                .SeedData();
            
        }

    }
}

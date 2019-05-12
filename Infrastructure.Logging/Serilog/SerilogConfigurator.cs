using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.RollingFile;

namespace Infrastructure.Logging.Serilog
{
    public static class SerilogConfigurator
    {
        /// <summary>Sets Serilog as the logging provider with default configuration of DotNetCoreInstantFramework.</summary>
        /// <remarks>
        /// A <see cref="T:Microsoft.AspNetCore.Hosting.WebHostBuilderContext" /> is supplied so that configuration and hosting information can be used.
        /// The logger will be shut down when application services are disposed.
        /// </remarks>
        /// <param name="builder">The web host builder to configure.</param>
        /// <param name="preserveStaticLogger">Indicates whether to preserve the value of <see cref="P:Serilog.LogMode.Logger" />.</param>
        /// <returns>The web host builder.</returns>
        public static IWebHostBuilder UseSerilogCustomized(this IWebHostBuilder builder, bool preserveStaticLogger = false)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));
            builder.UseSerilog(Config, preserveStaticLogger);
            return builder;
        }

        private static void Config(WebHostBuilderContext hostingContext, LoggerConfiguration loggerConfiguration)
        {

            var rollingFilePath = $"./logs/{hostingContext.Configuration.GetSection("Logging:RollingFilePrefix").Value}-{{Date}}.txt";
            var compactRollingFilePath = $"./logs/compact/{hostingContext.Configuration.GetSection("Logging:RollingFilePrefix").Value}-{{Date}}.json";

            Environment.SetEnvironmentVariable("BASEDIR", Directory.GetCurrentDirectory(), EnvironmentVariableTarget.Process);

            loggerConfiguration.MinimumLevel.Verbose() //Set to highest level of logging (as any sinks may want to restrict it to Errors only)
                .Enrich.WithProcessId()
                .Enrich.WithProcessName()
                .Enrich.WithMachineName()
                .Enrich.WithProperty("AppDomainId", AppDomain.CurrentDomain.Id)

                //Main .txt logfile
                .WriteTo.RollingFile(rollingFilePath, restrictedToMinimumLevel: LogEventLevel.Verbose,
                    retainedFileCountLimit: null, //Setting to null means we keep all files - default is 31 days
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss,fff} [/M{MachineName}/P{ProcessId}/D{AppDomainId}/T{ThreadId}] {Level}  {SourceContext} - {Message:lj}{NewLine}{Exception}")

                //.clef format (Compact log event format, that can be imported into local SEQ & will make searching/filtering logs easier)
                .WriteTo.RollingFile(new CompactJsonFormatter(), compactRollingFilePath,
                    retainedFileCountLimit: null,
                    restrictedToMinimumLevel: LogEventLevel.Verbose)

                //Read from main serilog.config file
                .ReadFrom.AppSettings(filePath: Path.Combine(Directory.GetCurrentDirectory(), @"config\serilog.config"))

                .WriteTo.Logger(cfg =>
                    cfg
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                        .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
                        .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(hostingContext.Configuration.GetSection("ElasticSearch:Url").Value))
                        {
                            IndexFormat = hostingContext.Configuration.GetSection("ElasticSearch:IndexFormat").Value,
                            AutoRegisterTemplate = true,
                            BufferBaseFilename = "./logs/buffer/elastic-buffer",
                            RegisterTemplateFailure = RegisterTemplateRecovery.IndexAnyway,
                            FailureCallback = e => Console.WriteLine("Unable to submit event to ElasticSearch " + e.MessageTemplate),
                            EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                               EmitEventFailureHandling.WriteToFailureSink |
                                               EmitEventFailureHandling.RaiseCallback,
                            FailureSink = new RollingFileSink("./logs/failures/fail-{Date}.txt", new JsonFormatter(), null, null),
                            CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true)
                        })
                        )
                //A nested logger - where any user configured sinks via config can not effect the main logger above
                .WriteTo.Logger(cfg =>
                cfg.ReadFrom.AppSettings(filePath: @"./config/serilog.user.config"));
        }
    }
}

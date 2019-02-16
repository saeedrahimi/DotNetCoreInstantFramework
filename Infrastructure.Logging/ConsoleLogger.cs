using Core.Contract.Logger;
using Core.Contract.Services.Shared;
using Serilog;
using Serilog.Core;
using ILogger = Core.Contract.Logger.ILogger;

namespace Infrastructure.Logging
{
    public class ConsoleLogger:ILogger
    {
        private readonly Logger _log;

        public ConsoleLogger()
        {
            _log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }


        public void Log(LogMode logMode, string message)
        {
            switch (logMode)
            {
                case LogMode.Normal:
                    _log.Information(message);
                    break;
                case LogMode.Exception:
                    _log.Fatal(message);
                    break;
            }
        }


        

    }
}

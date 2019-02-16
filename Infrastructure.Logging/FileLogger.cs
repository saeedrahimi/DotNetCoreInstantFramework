using Core.Contract.Logger;
using Core.Contract.Services.Shared;
using Serilog;
using Serilog.Core;
using ILogger = Core.Contract.Logger.ILogger;

namespace Infrastructure.Logging
{
    public class FileLogger : ILogger
    {
        private readonly Logger _log;

        public FileLogger()
        {
            _log = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
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

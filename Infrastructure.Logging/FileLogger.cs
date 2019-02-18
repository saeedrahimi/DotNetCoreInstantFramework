using Core.Domain.Contract.Logger;
using Serilog;
using Serilog.Core;
using ILogger = Core.Domain.Contract.Logger.ILogger;

namespace Infrastructure.Logging
{
    public class FileLogger : Core.Domain.Contract.Logger.ILogger
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

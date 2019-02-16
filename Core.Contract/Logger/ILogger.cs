using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Contract.Logger
{

    public enum LogMode
    {
        Non = 0,
        Normal = 2,
        Exception = 3

    }

    public interface ILogger
    {
        void Log(LogMode logMode, string message);
    }
}

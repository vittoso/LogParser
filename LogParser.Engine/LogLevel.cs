using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Engine
{
    [Flags]
    public enum LogLevel
    {
        None = 0,

        Trace = 1,

        Debug = 2,

        Info = 4,

        Warning = 8,

        Error = 16,

        Fatal = 32,

        All = Trace | Debug | Info | Warning | Error | Fatal
    }
}

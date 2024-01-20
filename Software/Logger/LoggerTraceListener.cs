using System.Diagnostics;

namespace Software.Logger
{
    public class LoggerTraceListener : TraceListener
    {
        private readonly ILogger _logger;

        public LoggerTraceListener(ILogger logger)
        {
            _logger = logger;
        }
        public override void Write(string message)
        {
            _logger.Log(LogLevels.Info, "LISTEN ! " + message);
        }

        public override void WriteLine(string message)
        {
            _logger.Log(LogLevels.Info, "LISTEN ! " + message);
        }
    }
}

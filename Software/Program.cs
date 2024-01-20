using Software.Logger;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InitLoggerDemo initLoggerDemo = new InitLoggerDemo();
            initLoggerDemo.Showcase();

            // Showcase that even at nullcheck we can get a NullReferenceException
            // This is because the checked object has some  logic in the operator that throws the exception should the instance be null
            //NoInitLoggerDemo someClassWithoutInitiatedLogger = new NoInitLoggerDemo();
            //someClassWithoutInitiatedLogger.Showcase();

            //Service s = new Service();
            //s.DoService();

            EntryWithTraceListener entry = new EntryWithTraceListener();

            entry.DoEntryAction();
        }
    }

    public class LoggerTraceListener : TraceListener
    {
        private readonly Software.Logger.ILogger _logger;

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

    class InitLoggerDemo
    {
        public void Showcase()
        {
            BasicLogger _logger = new BasicLogger();

            _logger.Log(LogLevels.Info, "This is cool info");
            _logger.Log(LogLevels.Warn, "This is friendly warning");
            _logger.Log(LogLevels.Error, "This is bad error");
        }
    }

    /// <summary>
    /// Some class without initiated logger
    /// aiming at reproducing a problem I am facing.
    /// I am in a situation where the _logger cannot be initialized
    /// </summary>
    public class NoInitLoggerDemo
    {
        BasicLogger _logger; // purposely not initiating logger.


        /// <summary>
        /// Throws System.NullReferenceException on purpose
        /// </summary>
        public void Showcase()
        {
            if (_logger != null)
                _logger.Log(LogLevels.Info, "Will it blend?");
        }

    }
}

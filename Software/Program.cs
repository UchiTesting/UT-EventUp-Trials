using Software.Logger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicLogger _logger = new   BasicLogger();

            _logger.Log(LogLevels.Info, "This is cool info");
            _logger.Log(LogLevels.Warn, "This is friendly warning");
            _logger.Log(LogLevels.Error, "This is bad error");

            NoInitLoggerDemo someClassWithoutInitiatedLogger = new NoInitLoggerDemo();

            someClassWithoutInitiatedLogger.DoAnything();
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
        public void DoAnything()
        {
            _logger.Log(LogLevels.Info, "Will it blend?");
        }

    }
}

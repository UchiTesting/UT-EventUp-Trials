using Software.Logger;

using System.Diagnostics;

namespace Software.Entry
{
    /// <summary>
    /// Entry class using the Service
    /// This class has a dependency on the logger which cannot be null checked
    /// Logger is fine here but putting log into the service breaks it when the context changes and it is not initialised
    /// Typically into the tests.
    /// This causes stackoverflow because there are other messages displayed using the Trace methods which cause infinite loop.
    /// 
    /// Not a usable option unfortunately.
    /// </summary>
    internal class EntryWithTraceListener
    {
        BasicLogger _logger = new BasicLogger();
        Service service = new Service();

        public EntryWithTraceListener()
        {
            Trace.Listeners.Add(new LoggerTraceListener(_logger));
        }

        public void DoEntryAction()
        {
            service.DoService();
            _logger.Log(LogLevels.Info, "Logging anything from Entry class");
        }
    }
}

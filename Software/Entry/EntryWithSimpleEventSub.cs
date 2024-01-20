using Software.Logger;
using Software.Service;

namespace Software.Entry
{
    /// <summary>
    /// This version will subscribe to services events
    /// </summary>
    internal class EntryWithSimpleEventSub
    {
        BasicLogger _logger = new BasicLogger();
        BasicEventService service = new BasicEventService();

        public EntryWithSimpleEventSub()
        {
            // Register to the service used internally
            service.MessageSent += OnMessageSent;
        }

        public void DoEntryAction()
        {
            service.DoService();
        }

        public void OnMessageSent(object sender, BasicEventArgs e)
        {
            LogLevels l = LogLevelsInfo.GetLogLevelEnumValueFromString(e.LogLevel);

            _logger.Log(l, "Logging anything from event Entry class");
        }
    }
}

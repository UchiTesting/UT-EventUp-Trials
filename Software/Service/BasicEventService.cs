using Software.Logger;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software.Service
{
    /// <summary>
    /// A service exposing an event aiming at publishing event info
    /// </summary>
    public class BasicEventService : IService
    {
        public delegate void MessageSentEventHandler(object sender, BasicEventArgs e);
        public event MessageSentEventHandler MessageSent;

        protected virtual void OnMessageSent(LogLevels logLevel, string message)
            => MessageSent?.Invoke(this,
                new BasicEventArgs
                {
                    Source = this.GetType().Name,
                    LogLevel = logLevel.ToString().ToUpperInvariant(),
                    Message = message
                });

        public void DoService()
        {
            // Any theoretical set of actions before...
            string message = "We are displaying anything in the basic service";
            OnMessageSent(LogLevels.Warn, message);
        }
    }

    public class BasicEventArgs
    {
        public string Source { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
    }
}
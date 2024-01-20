using System;
using System.Diagnostics;
using System.Text;

namespace Software.Logger
{
    public class BasicLogger : ILogger
    {
        public void Log(LogLevels logLevel, string message)
        {
            // Listeners à creuser
            //var traceObject = System.Diagnostics.Trace.Listeners;

            message = AugmentMessage(logLevel, message);

            switch (logLevel)
            {
                case LogLevels.Info: LogInfo(message); break;
                case LogLevels.Warn: LogWarning(message); break;
                case LogLevels.Error: LogError(message); break;
                default: throw new Exception("How come you");
            }

        }

        private string AugmentMessage(LogLevels logLevel, string message)
        {
            StringBuilder sb = new StringBuilder();

            sb
                .Append(DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss,fff"))
                .Append(" | ")
                .Append(logLevel.ToString().ToUpperInvariant())
                .Append(" | ")
                .Append(message);

            return sb.ToString();
        }

        private void LogInfo(string augmentedMessage) => DisplayMessage(augmentedMessage);
        private void LogWarning(string augmentedMessage) => DisplayMessage(augmentedMessage);
        private void LogError(string augmentedMessage) => DisplayMessage(augmentedMessage);

        public static bool operator ==(BasicLogger a, BasicLogger b)
        {
            if (a.Equals(null) || b.Equals(null))
                throw new NullReferenceException("I was made to bother you baby. Were you made to bother me !");

            return (a == b);
        }
        public static bool operator !=(BasicLogger a, BasicLogger b)
        {
            if (a.Equals(null) || b.Equals(null))
                throw new NullReferenceException("I was made to bother you baby. Were you made to bother me !");

            return (a != b);
        }

        public void DisplayMessage(string message)
        {
#if DEBUG
            Debug.WriteLine(message);
#else
    Console.WriteLine(message);
#endif
        }
    }
}

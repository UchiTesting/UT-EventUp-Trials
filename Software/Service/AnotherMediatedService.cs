using Software.Entry;
using Software.Logger;

namespace Software.Service
{
    public class AnotherMediatedService : MediatedParnter
    {
        public AnotherMediatedService(ILogMediator logMediator) : base(logMediator) { }

        public void DoAnythingAnotherWay(string anyParam)
        {
            // Perform any different logic
            string message = $"Did anything another way with parameter {anyParam}";
            System.Diagnostics.Trace.TraceWarning(message);

            _logMediator?.Notify(this,
                new BasicEventArgs { 
                    LogLevel = LogLevels.Warn.ToString(), 
                    Message = message,
                    Source = this.GetType().Name
                });
        }
    }
}
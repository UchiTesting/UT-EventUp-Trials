using Software.Entry;
using Software.Logger;

namespace Software.Service
{
    public class MediatedService : MediatedParnter
    {
        public MediatedService(ILogMediator logMediator) : base(logMediator) { }

        public void DoAnything()
        {
            // Perform Any logic
            string message = "Did anything from mediated service";

            System.Diagnostics.Trace.TraceInformation(message);

            //_logMediator?.Notify( // This breaks in tests becuse of NullReferenceException
            _logMediator?.Notify(this, // this won't
                new BasicEventArgs
                {
                    LogLevel = LogLevels.Info.ToString(),
                    Message = message,
                    Source = this.GetType().Name
                });
        }

        public void DoAnythingSendError()
        {
            // Perform Any logic
            string message = "Did anything from mediated service as error";

            System.Diagnostics.Trace.TraceError(message);

            //_logMediator?.Notify( // This breaks in tests becuse of NullReferenceException
            _logMediator?.Notify(this, // this won't
                new BasicEventArgs
                {
                    LogLevel = LogLevels.Error.ToString(),
                    Message = message,
                    Source = this.GetType().Name
                });
        }
    }
}
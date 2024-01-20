using System.ComponentModel.Design;

namespace Software.Service
{
    /// <summary>
    ///  Representative of any service.
    ///  Contains calls to System.Diagnostics.Trace tracing methods.
    /// </summary>
    public class BasicService : IService
    {
        public void DoService()
        {
            System.Diagnostics.Trace.TraceInformation("We are displaying anything in the basic service");
        }
    }
}

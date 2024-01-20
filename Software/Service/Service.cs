namespace Software.Service
{
    /// <summary>
    ///  Representative of any service.
    ///  Contains calls to System.Diagnostics.Trace tracing methods.
    /// </summary>
    public class Service
    {
        public void DoService()
        {
            System.Diagnostics.Trace.TraceInformation("We are displaying anything in the service");
        }
    }
}

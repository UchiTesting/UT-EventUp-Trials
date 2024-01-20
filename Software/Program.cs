using Software.Demo;
using Software.Entry;

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
}

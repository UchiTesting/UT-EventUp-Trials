using Software.Demo;
using Software.Entry;
using Software.Service;

using System;
using System.Threading;

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

            // Uses the mechanism provided natively to add listeners to Any Trace method
            // Debug seems to be an alias. Because both caused the infinite loop issue.
            //EntryWithTraceListener entryWithTraceListener = new EntryWithTraceListener();
            //entryWithTraceListener.DoEntryAction();

            //EntryWithSimpleEventSubDemo();

            EntryWithMediatorDemo();
        }

        private static void EntryWithMediatorDemo()
        {
            EntryWithMediator entryWithMediator = new EntryWithMediator();

            entryWithMediator.DoAnotherAction("Hello");
            entryWithMediator.DoEntryAction();
            entryWithMediator.DoAnotherAction("World!");
        }

        static void EntryWithSimpleEventSubDemo() {
            EntryWithSimpleEventSub entryWithSimpleEventSub = new EntryWithSimpleEventSub();
            BasicEventService basicEventService = new BasicEventService();

            //Calls the service method which will raise the MessageSent event
            entryWithSimpleEventSub.DoEntryAction();

            // Without this, the messages bellow won't display to screen
            // because it is an independant instance of the service
            basicEventService.MessageSent += entryWithSimpleEventSub.OnMessageSent;
            basicEventService.DoService();
            Thread.Sleep(100);
            basicEventService.DoService();
            Thread.Sleep(1900);
            basicEventService.DoService();
        }
    }
}

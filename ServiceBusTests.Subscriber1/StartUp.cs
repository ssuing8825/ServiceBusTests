using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests.Subscriber1
{
    public class StartUp : IWantToRunWhenBusStartsAndStops
    {
        /// <summary>
        /// Performs startup tasks when the bus starts.
        /// </summary>
        public void Start()
        {
            Console.Out.WriteLine("The ServiceBusTests.Subscriber endpoint is now started and subscribed to events from ServiceBusTests.");
        }

        /// <summary>
        /// Performs cleanup tasks when the bus stops.
        /// </summary>
        public void Stop()
        {
        }

    }
}

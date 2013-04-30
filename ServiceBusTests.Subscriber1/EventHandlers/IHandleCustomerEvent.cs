using NServiceBus;
using ServiceBusTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests.Subscriber1.EventHandlers
{
    public class CustomerMessageHandler : IHandleMessages<ICustomerUpdatedEvent>
    {
        public void Handle(ICustomerUpdatedEvent message)
        {
            Console.WriteLine("Handling Customer message {0}", message.Customer.name);
        }
    }
}

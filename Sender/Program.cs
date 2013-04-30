using NServiceBus;
using ServiceBusTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    class Program
    {
        static void Main(string[] args)
        {

            IBus bus = CreateBusCore();
            //bus.Publish<IPolicyAndCustomerChange>(customerCreatedEvent => customerCreatedEvent.PolicyAndCustomer = customerAndPolicy);
            bus.Send<PolicyAndCustomerMessage>(m =>
            {
                m.CustomerId = 23;
                m.PolicyId = 234;
                m.CorrelationId = Guid.NewGuid();
            });

            Console.WriteLine("Message Published");
        }

        static IBus CreateBusCore()
        {
            return Configure.With()
                     .DefineEndpointName("ServiceBusTests")
                     .DefaultBuilder()
                     .XmlSerializer()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .InMemorySubscriptionStorage()
                     .UseInMemoryTimeoutPersister()
                     .UnicastBus()
                     .CreateBus()
                     .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
                                           .Install());
        }
    }
}

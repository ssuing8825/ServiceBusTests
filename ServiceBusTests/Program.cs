using NServiceBus;
using ServiceBusTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ncustomer = new Customer { Id = 2, name = "Steve" };
            //IBus bus = CreateBusCore();
            //bus.Publish<ICustomerUpdatedEvent>(customerCreatedEvent => customerCreatedEvent.Customer = ncustomer);
            //Console.WriteLine("Message Published");

            //Console.ReadLine();

             var customerAndPolicy = new PolicyAndCustomerMessage { CorrelationId = Guid.NewGuid(), CustomerId = 3, PolicyId = 4 };

            IBus bus = CreateBusCoreSaga();
            //bus.Publish<IPolicyAndCustomerChange>(customerCreatedEvent => customerCreatedEvent.PolicyAndCustomer = customerAndPolicy);
            bus.Send<PolicyAndCustomerMessage>(m =>
             {
                 m.CustomerId = customerAndPolicy.CustomerId;
                 m.PolicyId = customerAndPolicy.PolicyId;
                 m.CorrelationId = Guid.NewGuid();
             });

            Console.WriteLine("Message Published");

            Console.ReadLine();

        }

        //static IBus CreateBusCore()
        //{
        //    return Configure.With()
        //             .DefineEndpointName("ServiceBusTests")
        //             .DefaultBuilder()
        //             .XmlSerializer()
        //             .UseTransport<NServiceBus.RabbitMQ>()
        //             .InMemorySubscriptionStorage()
        //             .UseInMemoryTimeoutPersister()
        //             .UnicastBus()
        //             .CreateBus()
        //             .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>()
        //                                   .Install());
        //}

        static IBus CreateBusCoreSaga()
        {
            return Configure.With()
                     .DefineEndpointName("ServiceBusSagaTests")
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

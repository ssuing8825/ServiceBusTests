using NServiceBus;
using NServiceBus.Saga;
using ServiceBusTests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests.Saga
{
    public class PolicyChangeSaga : Saga<PolicyChangeSagaData>,
        IAmStartedByMessages<PolicyAndCustomerMessage>,
        IHandleMessages<CustomerMessage>,
           IHandleMessages<PolicyMessage>
    {
        public override void ConfigureHowToFindSaga()
        {
            ConfigureMapping<PolicyAndCustomerMessage>(s => s.CorrelationId, m => m.CorrelationId);
            ConfigureMapping<CustomerMessage>(s => s.CorrelationId, m => m.CorrelationId);
        }

        public void Handle(PolicyAndCustomerMessage message)
        {
            Console.WriteLine("Recieved message: " + message);

            this.Data.CorrelationId = message.CorrelationId;
            this.Data.PolicyId = message.PolicyId;
            this.Data.CustomerId = message.CustomerId;
            //// rest of the code to handle Message1

            //Could do something here. 
            Bus.Send<CustomerMessage>(customerCreatedEvent => 
                {
                    customerCreatedEvent.CorrelationId = this.Data.CorrelationId;
                    customerCreatedEvent.Id = this.Data.CustomerId;
                    customerCreatedEvent.name = "Steven the Name";

                });
         
        }
        public void Handle(CustomerMessage message)
        {
            Console.WriteLine("Recieved Customer message here message: " + message);

            // rest of the code to handle Message2
        //    Bus.Publish<IPolicyUpdatedEvent>(customerCreatedEvent => customerCreatedEvent.Policy = this.Data.Policy  );
         
        }

        public void Handle(PolicyMessage message)
        {
            Console.WriteLine("Recieved policy message here message: " + message);


            // code to handle Message3
        }

    }
}

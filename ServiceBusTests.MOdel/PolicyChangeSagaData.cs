using NServiceBus;
using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests.Model
{
    public class PolicyChangeSagaData : IContainSagaData
    {
        // the following properties are mandatory
        public Guid Id { get; set; }
        public string Originator { get; set; }
        public string OriginalMessageId { get; set; }

        // all other properties you want persisted
        public Guid CorrelationId { get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
       
    }

    public class PolicyMessage : IMessage
    {
        [Unique]
        public Guid CorrelationId { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
    }

    public class CustomerMessage : IMessage
    {
        [Unique]
        public Guid CorrelationId { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
    }

    public class PolicyAndCustomerMessage : IMessage
    {
        [Unique]
        public Guid CorrelationId { get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }

    }

    public class IPolicyAndCustomerChange : IMessage
    {
        public Guid CorrelationId { get; set; }
        public int PolicyId { get; set; }
        public int CustomerId { get; set; }
    }
}

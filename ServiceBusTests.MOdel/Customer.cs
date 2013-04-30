using NServiceBus;
using NServiceBus.Saga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusTests.Model
{
    public class Customer : IMessage
    {
        [Unique]
        public Guid CorrelationId { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
    }
}

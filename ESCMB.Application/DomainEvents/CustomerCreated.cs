using Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.DomainEvents
{
    internal sealed class CustomerCreated : DomainEvent
    {
        public string Id { get; set; }

        public string CuilCuit { get; set; }

        public string FirstName { get; set; }
    }
}

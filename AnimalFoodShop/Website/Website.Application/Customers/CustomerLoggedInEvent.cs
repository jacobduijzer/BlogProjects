using System;
using System.Collections.Generic;
using SharedKernel.Events;

namespace Website.Application.Customers
{
    public class CustomerLoggedInEvent : IEvent
    {
        public readonly Guid CustomerId;

        public readonly List<Guid> DeliveryAddressIds;

        public CustomerLoggedInEvent(Guid customerId, List<Guid> deliveryAddressIds)
        {
            CustomerId = customerId;
            DeliveryAddressIds = deliveryAddressIds;
        }
    }
}

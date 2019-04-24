using MediatR;
using Website.Application.Customers;

namespace Website.Application.Products
{
    public class AddProductsToCacheNotification : INotification
    {
        public readonly CustomerLoggedInEvent CustomerLoggedInEvent;

        public AddProductsToCacheNotification(CustomerLoggedInEvent customerLoggedInEvent) =>
            CustomerLoggedInEvent = customerLoggedInEvent;
    }
}

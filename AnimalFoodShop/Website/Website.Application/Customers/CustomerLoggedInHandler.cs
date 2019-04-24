using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SharedKernel.Events;

namespace Website.Application.Customers
{
    public class CustomerLoggedInHandler : IEventHandler<CustomerLoggedInEvent>
    {
        private readonly ILogger<CustomerLoggedInHandler> _logger;

        public CustomerLoggedInHandler(ILogger<CustomerLoggedInHandler> logger) =>
            _logger = logger;

        public async Task HandleAsync(CustomerLoggedInEvent @event)
        {
            _logger.LogDebug("CustomerLoggedInHandler-HandleAsync-Started");
            await Task.Delay(5000);
            _logger.LogDebug("CustomerLoggedInHandler-HandleAsync-Finished");
        }
    }
}

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SharedKernel.Events;
using Website.Application.Products;

namespace Website.Application.Customers
{
    public class CustomerLoggedInHandler : IEventHandler<CustomerLoggedInEvent>
    {
        private readonly ICachedProductsDecorator _cachedProductsService;
        private readonly ILogger<CustomerLoggedInHandler> _logger;

        public CustomerLoggedInHandler(ICachedProductsDecorator cachedProductsService, ILogger<CustomerLoggedInHandler> logger)
        {
            _cachedProductsService = cachedProductsService;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerLoggedInEvent @event)
        {
            _logger.LogDebug("CustomerLoggedInHandler-HandleAsync-Started");
            await _cachedProductsService.GetAllProducts()
                .ConfigureAwait(false);
            _logger.LogDebug("CustomerLoggedInHandler-HandleAsync-Finished");
        }
    }
}

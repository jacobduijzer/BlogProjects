using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SharedKernel.Events;
using Website.Application.Products;

namespace Website.Web
{
    public class PopulateCacheWorker : IHostedService, INotificationHandler<AddProductsToCacheNotification>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<PopulateCacheWorker> _logger;

        public PopulateCacheWorker(IServiceProvider serviceProvider, ILogger<PopulateCacheWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task Handle(AddProductsToCacheNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogDebug("PopulateCacheWorker-Handle");
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                var dispatcher = scopedProvider.GetRequiredService<IEventDispatcher>();
                await dispatcher.DispatchAsync(notification.CustomerLoggedInEvent);
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("PopulateCacheWorker-StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug("PopulateCacheWorker-StopAsync");
            return Task.CompletedTask;
        }
    }
}

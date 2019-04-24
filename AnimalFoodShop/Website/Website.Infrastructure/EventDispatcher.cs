using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedKernel.Events;

namespace Website.Infrastructure
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EventDispatcher> _logger;

        public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task DispatchAsync<T>(params T[] events) where T : IEvent
        {
            foreach(var @event in events)
            {
                if (@event == null)
                    throw new ArgumentNullException(nameof(@event), "Event can not be null.");

                var eventType = @event.GetType();
                var handlerType = typeof(IEventHandler<>).MakeGenericType(eventType);
                object handler;
                using (var scope = _serviceProvider.CreateScope())
                {
                    var scopedProvider = scope.ServiceProvider;
                    // todo: handle exception
                    handler = scopedProvider.GetRequiredService(handlerType);
                    if (handler == null)
                        return;

                    var method = handler
                        .GetType()
                        .GetRuntimeMethods()
                        .First(x => x.Name.Equals("HandleAsync"));

                    await (Task)((dynamic)handler).HandleAsync(@event);
                }
            }
        }
    }
}

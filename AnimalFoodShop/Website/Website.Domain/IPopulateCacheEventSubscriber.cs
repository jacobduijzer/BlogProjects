using System;
using System.Threading.Tasks;

namespace Website.Domain
{
    public interface IPopulateCacheEventSubscriber
    {
        Task<IDisposable> SubscribeAsync<T>(Guid deliveryAddressId) where T : class;
    }
}

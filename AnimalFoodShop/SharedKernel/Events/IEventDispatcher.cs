using System.Threading.Tasks;

namespace SharedKernel.Events
{
    public interface IEventDispatcher
    {
        Task DispatchAsync<T>(params T[] events) where T : IEvent;
    }
}

using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Dispatchers.Interfaces
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}

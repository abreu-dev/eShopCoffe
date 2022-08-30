using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Dispatchers.Interfaces
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent @event, CancellationToken cancellationToken = default) where TEvent : IEvent;
    }
}

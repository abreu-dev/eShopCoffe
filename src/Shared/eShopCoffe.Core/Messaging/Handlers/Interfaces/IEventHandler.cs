using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Handlers.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}

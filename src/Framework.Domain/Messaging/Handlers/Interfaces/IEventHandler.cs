using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Handlers.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken = default);
    }
}

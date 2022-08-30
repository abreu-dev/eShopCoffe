using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Handlers.Interfaces
{
    public interface INotificationHandler
    {
        bool HasNotifications { get; }
        IEnumerable<INotification> GetNotifications();

        Task Handle(INotification notification, CancellationToken cancellationToken = default);
    }
}

using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Handlers.Interfaces
{
    public interface INotificationHandler
    {
        bool HasNotifications { get; }
        IEnumerable<INotification> GetNotifications();

        Task Handle(INotification notification, CancellationToken cancellationToken = default);
    }
}

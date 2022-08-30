using Framework.Core.Messaging.Handlers.Interfaces;
using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Handlers
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly ICollection<INotification> _notifications;

        public NotificationHandler()
        {
            _notifications = new List<INotification>();
        }

        public bool HasNotifications => _notifications.Any();

        public IEnumerable<INotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(INotification notification, CancellationToken cancellationToken = default)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }
    }
}

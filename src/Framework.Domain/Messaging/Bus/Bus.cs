using Framework.Core.Messaging.Bus.Interfaces;
using Framework.Core.Messaging.Dispatchers.Interfaces;
using Framework.Core.Messaging.Handlers.Interfaces;
using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Bus
{
    public class Bus : IBus
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly INotificationHandler _notificationHandler;

        public Bus(ICommandDispatcher commandDispatcher,
                   IEventDispatcher eventDispatcher,
                   IQueryDispatcher queryDispatcher,
                   INotificationHandler notificationHandler)
        {
            _commandDispatcher = commandDispatcher;
            _eventDispatcher = eventDispatcher;
            _queryDispatcher = queryDispatcher;
            _notificationHandler = notificationHandler;
        }

        public Task Command<TCommand>(TCommand command, CancellationToken cancellationToken = default)
            where TCommand : ICommand
        {
            return _commandDispatcher.Dispatch(command);
        }

        public Task Event<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : IEvent
        {
            return _eventDispatcher.Dispatch(@event);
        }

        public Task Notification<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
            where TNotification : INotification
        {
            return _notificationHandler.Handle(notification, cancellationToken);
        }

        public Task<TResult> Query<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult
        {
            return _queryDispatcher.Dispatch<TQuery, TResult>(query);
        }
    }
}

using eShopCoffe.Core.Messaging.Bus;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Dispatchers.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Tests.Messaging.Bus
{
    public class MemoryBusTests
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IEventDispatcher _eventDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly INotificationHandler _notificationHandler;
        private readonly IBus _bus;

        public MemoryBusTests()
        {
            _commandDispatcher = Substitute.For<ICommandDispatcher>();
            _eventDispatcher = Substitute.For<IEventDispatcher>();
            _queryDispatcher = Substitute.For<IQueryDispatcher>();
            _notificationHandler = Substitute.For<INotificationHandler>();

            _bus = new MemoryBus(_commandDispatcher,
                                 _eventDispatcher,
                                 _queryDispatcher,
                                 _notificationHandler);
        }

        [Fact]
        public void Command_ShouldCallCommandDispatcher()
        {
            // Arrange
            var command = Substitute.For<ICommand>();

            // Act
            _bus.Command(command);

            // Assert
            _commandDispatcher.Received(1).Dispatch(command);
        }

        [Fact]
        public void Event_ShouldCallEventDispatcher()
        {
            // Arrange
            var @event = Substitute.For<IEvent>();

            // Act
            _bus.Event(@event);

            // Assert
            _eventDispatcher.Received(1).Dispatch(@event);
        }

        [Fact]
        public void Notification_ShouldCallNotificationHandler()
        {
            // Arrange
            var notification = Substitute.For<INotification>();

            // Act
            _bus.Notification(notification);

            // Assert
            _notificationHandler.Received(1).Handle(notification);
        }

        [Fact]
        public void Query_ShouldCallEventDispatcher()
        {
            // Arrange
            var query = Substitute.For<IQuery<IQueryResult>>();

            // Act
            _bus.Query<IQuery<IQueryResult>, IQueryResult>(query);

            // Assert
            _queryDispatcher.Received(1).Dispatch<IQuery<IQueryResult>, IQueryResult>(query);
        }
    }
}

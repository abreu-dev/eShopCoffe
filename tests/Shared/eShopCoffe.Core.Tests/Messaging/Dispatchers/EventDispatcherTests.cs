using eShopCoffe.Core.Messaging.Dispatchers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Core.Tests.Messaging.Dispatchers
{
    public class EventDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenFoundEventHandler_ShouldCallHandle()
        {
            // Arrange
            var mockEvent = Substitute.For<IEvent>();
            var cancellationToken = CancellationToken.None;

            var mockEventHandler = Substitute.For<IEventHandler<IEvent>>();
            mockEventHandler.Handle(Arg.Is(mockEvent), Arg.Is(cancellationToken)).Returns(Task.FromResult(true));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(x => mockEventHandler);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new EventDispatcher(serviceProvider);

            // Act
            dispatcher.Dispatch(mockEvent, cancellationToken).Wait();

            // Assert
            mockEventHandler.ReceivedWithAnyArgs(1).Handle(Arg.Any<IEvent>(), Arg.Any<CancellationToken>());
            mockEventHandler.Received(1).Handle(Arg.Is(mockEvent), Arg.Is(cancellationToken));
        }

        [Fact]
        public void Dispatch_WhenNotFoundEventHandler_ShouldThrowException()
        {
            // Arrange
            var mockEvent = Substitute.For<IEvent>();
            var cancellationToken = CancellationToken.None;

            var mockEventHandler = Substitute.For<IEventHandler<IEvent>>();
            mockEventHandler.Handle(Arg.Is(mockEvent), Arg.Is(cancellationToken)).Returns(Task.FromResult(true));

            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new EventDispatcher(serviceProvider);

            // Act
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => dispatcher.Dispatch(mockEvent, cancellationToken));

            // Assert
            exception.Should().NotBeNull();
            mockEventHandler.DidNotReceiveWithAnyArgs().Handle(Arg.Any<IEvent>(), Arg.Any<CancellationToken>());
        }
    }
}

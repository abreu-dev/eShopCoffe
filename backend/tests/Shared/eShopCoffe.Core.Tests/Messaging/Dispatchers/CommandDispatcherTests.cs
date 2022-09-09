using eShopCoffe.Core.Messaging.Dispatchers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Core.Tests.Messaging.Dispatchers
{
    public class CommandDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenFoundCommandHandler_ShouldCallHandle()
        {
            // Arrange
            var mockCommand = Substitute.For<ICommand>();
            var cancellationToken = CancellationToken.None;

            var mockCommandHandler = Substitute.For<ICommandHandler<ICommand>>();
            mockCommandHandler.Handle(Arg.Is(mockCommand), Arg.Is(cancellationToken)).Returns(Task.FromResult(true));

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(x => mockCommandHandler);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new CommandDispatcher(serviceProvider);

            // Act
            dispatcher.Dispatch(mockCommand, cancellationToken).Wait();

            // Assert
            mockCommandHandler.ReceivedWithAnyArgs(1).Handle(Arg.Any<ICommand>(), Arg.Any<CancellationToken>());
            mockCommandHandler.Received(1).Handle(Arg.Is(mockCommand), Arg.Is(cancellationToken));
        }

        [Fact]
        public void Dispatch_WhenNotFoundCommandHandler_ShouldThrowException()
        {
            // Arrange
            var mockCommand = Substitute.For<ICommand>();
            var cancellationToken = CancellationToken.None;

            var mockCommandHandler = Substitute.For<ICommandHandler<ICommand>>();
            mockCommandHandler.Handle(Arg.Is(mockCommand), Arg.Is(cancellationToken)).Returns(Task.FromResult(true));

            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new CommandDispatcher(serviceProvider);

            // Act
            var exception = Assert.ThrowsAsync<InvalidOperationException>(() => dispatcher.Dispatch(mockCommand, cancellationToken));

            // Assert
            exception.Should().NotBeNull();
            mockCommandHandler.DidNotReceiveWithAnyArgs().Handle(Arg.Any<ICommand>(), Arg.Any<CancellationToken>());
        }
    }
}

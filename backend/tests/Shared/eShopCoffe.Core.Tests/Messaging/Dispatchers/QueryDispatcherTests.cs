using eShopCoffe.Core.Messaging.Dispatchers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Core.Tests.Messaging.Dispatchers
{
    public class QueryDispatcherTests
    {
        [Fact]
        public void Dispatch_WhenFoundQueryHandler_ShouldCallHandle()
        {
            // Arrange
            var mockQuery = Substitute.For<IQuery<IQueryResult>>();
            var cancellationToken = CancellationToken.None;

            var mockQueryHandler = Substitute.For<IQueryHandler<IQuery<IQueryResult>, IQueryResult>>();
            var mockQueryHandlerResult = Substitute.For<IQueryResult>();
            mockQueryHandler.Handle(Arg.Is(mockQuery), Arg.Is(cancellationToken)).Returns(mockQueryHandlerResult);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(x => mockQueryHandler);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new QueryDispatcher(serviceProvider);

            // Act
            var result = dispatcher.Dispatch<IQuery<IQueryResult>, IQueryResult>(mockQuery, cancellationToken).Result;

            // Assert
            result.Should().Be(mockQueryHandlerResult);
            mockQueryHandler.ReceivedWithAnyArgs(1).Handle(Arg.Any<IQuery<IQueryResult>>(), Arg.Any<CancellationToken>());
            mockQueryHandler.Received(1).Handle(Arg.Is(mockQuery), Arg.Is(cancellationToken));
        }

        [Fact]
        public void Dispatch_WhenNotFoundQueryHandler_ShouldThrowException()
        {
            // Arrange
            var mockQuery = Substitute.For<IQuery<IQueryResult>>();
            var cancellationToken = CancellationToken.None;

            var mockQueryHandler = Substitute.For<IQueryHandler<IQuery<IQueryResult>, IQueryResult>>();
            var mockQueryHandlerResult = Substitute.For<IQueryResult>();
            mockQueryHandler.Handle(Arg.Is(mockQuery), Arg.Is(cancellationToken)).Returns(mockQueryHandlerResult);

            var serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var dispatcher = new QueryDispatcher(serviceProvider);

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => dispatcher.Dispatch<IQuery<IQueryResult>, IQueryResult>(mockQuery, cancellationToken).Result);

            // Assert
            exception.Should().NotBeNull();
            mockQueryHandler.DidNotReceiveWithAnyArgs().Handle(Arg.Any<IQuery<IQueryResult>>(), Arg.Any<CancellationToken>());
        }
    }
}

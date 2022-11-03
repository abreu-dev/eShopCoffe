using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Ordering.Domain.Commands.Handlers;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Domain.Tests
{
    public class OrderingDomainBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public OrderingDomainBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            OrderingDomainBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(1).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(ICommandHandler<AddOrderCommand>), typeof(OrderCommandHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

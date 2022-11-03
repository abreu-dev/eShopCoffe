using eShopCoffe.Ordering.Domain.Repositories;
using eShopCoffe.Ordering.Infra.Data.Adapters;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Infra.Data.Tests
{
    public class OrderingDataBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public OrderingDataBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            OrderingDataBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(4).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IOrderDataAdapter), typeof(OrderDataAdapter));
            ValidateService(typeof(IOrderEventDataAdapter), typeof(OrderEventDataAdapter));
            ValidateService(typeof(IOrderItemDataAdapter), typeof(OrderItemDataAdapter));
            ValidateService(typeof(IOrderRepository), typeof(OrderRepository));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

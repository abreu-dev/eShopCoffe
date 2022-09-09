using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Basket.Infra.Data.Adapters;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Infra.Data.Tests
{
    public class BasketDataBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public BasketDataBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            BasketDataBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(3).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IBasketDataAdapter), typeof(BasketDataAdapter));
            ValidateService(typeof(IBasketItemDataAdapter), typeof(BasketItemDataAdapter));
            ValidateService(typeof(IBasketRepository), typeof(BasketRepository));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

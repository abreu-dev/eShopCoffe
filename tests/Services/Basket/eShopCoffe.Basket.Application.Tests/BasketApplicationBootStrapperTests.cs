using eShopCoffe.Basket.Application.Contracts.BasketContracts;
using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Application.Queries.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Application.Tests
{
    public class BasketApplicationBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public BasketApplicationBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllApplicationServices()
        {
            // Act
            BasketApplicationBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(1).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IQueryHandler<BasketQuery, BasketDto>), typeof(BasketQueryHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

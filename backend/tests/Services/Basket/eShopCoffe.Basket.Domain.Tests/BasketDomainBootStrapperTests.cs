using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Commands.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Domain.Tests
{
    public class BasketDomainBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public BasketDomainBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDomainServices()
        {
            // Act
            BasketDomainBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(2).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(ICommandHandler<AddOrUpdateBasketItemCommand>), typeof(BasketCommandHandler));
            ValidateService(typeof(ICommandHandler<RemoveBasketItemCommand>), typeof(BasketCommandHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

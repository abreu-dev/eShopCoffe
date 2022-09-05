using eShopCoffe.Catalog.Domain.Commands.Handlers;
using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Domain.Tests
{
    public class CatalogDomainBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public CatalogDomainBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDomainServices()
        {
            // Act
            CatalogDomainBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(3).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(ICommandHandler<AddProductCommand>), typeof(ProductCommandHandler));
            ValidateService(typeof(ICommandHandler<UpdateProductCommand>), typeof(ProductCommandHandler));
            ValidateService(typeof(ICommandHandler<RemoveProductCommand>), typeof(ProductCommandHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

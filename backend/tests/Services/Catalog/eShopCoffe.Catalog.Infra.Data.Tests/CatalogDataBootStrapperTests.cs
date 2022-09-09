using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Catalog.Infra.Data.Adapters;
using eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Catalog.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Infra.Data.Tests
{
    public class CatalogDataBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public CatalogDataBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            CatalogDataBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(2).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IProductDataAdapter), typeof(ProductDataAdapter));
            ValidateService(typeof(IProductRepository), typeof(ProductRepository));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

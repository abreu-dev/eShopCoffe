using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Queries.Handlers;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Application.Tests
{
    public class CatalogApplicationBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public CatalogApplicationBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllApplicationServices()
        {
            // Act
            CatalogApplicationBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(1).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>), typeof(ProductQueryHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

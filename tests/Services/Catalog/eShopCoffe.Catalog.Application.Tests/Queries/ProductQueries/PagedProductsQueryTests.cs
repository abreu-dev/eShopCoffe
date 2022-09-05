using eShopCoffe.Catalog.Application.Parameters.Interfaces;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;

namespace eShopCoffe.Catalog.Application.Tests.Queries.ProductQueries
{
    public class PagedProductsQueryTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var parameters = Substitute.For<IProductParameters>();

            // Act
            var query = new PagedProductsQuery(parameters);

            // Assert
            query.Parameters.Should().Be(parameters);
        }
    }
}

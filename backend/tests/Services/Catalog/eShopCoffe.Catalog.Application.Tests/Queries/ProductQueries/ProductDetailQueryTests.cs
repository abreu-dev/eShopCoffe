using eShopCoffe.Catalog.Application.Queries.ProductQueries;

namespace eShopCoffe.Catalog.Application.Tests.Queries.ProductQueries
{
    public class ProductDetailQueryTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var productId = Guid.NewGuid();

            // Act
            var query = new ProductDetailQuery(productId);

            // Assert
            query.ProductId.Should().Be(productId);
        }
    }
}

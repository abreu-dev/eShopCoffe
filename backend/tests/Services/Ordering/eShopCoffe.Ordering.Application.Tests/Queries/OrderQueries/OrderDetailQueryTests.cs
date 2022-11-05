using eShopCoffe.Ordering.Application.Queries.OrderQueries;

namespace eShopCoffe.Ordering.Application.Tests.Queries.OrderQueries
{
    public class OrderDetailQueryTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var orderId = Guid.NewGuid();

            // Act
            var query = new OrderDetailQuery(orderId);

            // Assert
            query.OrderId.Should().Be(orderId);
        }
    }
}

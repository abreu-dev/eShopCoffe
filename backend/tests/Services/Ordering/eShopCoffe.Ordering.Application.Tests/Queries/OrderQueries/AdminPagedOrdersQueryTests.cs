using eShopCoffe.Ordering.Application.Parameters.Interfaces;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;

namespace eShopCoffe.Ordering.Application.Tests.Queries.OrderQueries
{
    public class AdminPagedOrdersQueryTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var parameters = Substitute.For<IOrderParameters>();

            // Act
            var query = new AdminPagedOrdersQuery(parameters);

            // Assert
            query.Parameters.Should().Be(parameters);
        }
    }
}

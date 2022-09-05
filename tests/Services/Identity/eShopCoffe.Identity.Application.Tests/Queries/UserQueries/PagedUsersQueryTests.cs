using eShopCoffe.Identity.Application.Parameters.Interfaces;
using eShopCoffe.Identity.Application.Queries.UserQueries;

namespace eShopCoffe.Identity.Application.Tests.Queries.UserQueries
{
    public class PagedUsersQueryTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var parameters = Substitute.For<IUserParameters>();

            // Act
            var query = new PagedUsersQuery(parameters);

            // Assert
            query.Parameters.Should().Be(parameters);
        }
    }
}

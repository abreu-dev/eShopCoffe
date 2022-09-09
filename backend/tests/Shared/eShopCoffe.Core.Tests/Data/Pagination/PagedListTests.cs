using eShopCoffe.Core.Data.Pagination;

namespace eShopCoffe.Core.Tests.Data.Pagination
{
    public class PagedListTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var items = new List<ConcreteEntity>();
            var totalItems = 90;
            var currentPage = 1;
            var pageSize = 30;

            // Act
            var pagedList = new PagedList<ConcreteEntity>(items, totalItems, currentPage, pageSize);

            // Assert
            pagedList.Data.Should().BeEquivalentTo(items);
            pagedList.CurrentPage.Should().Be(currentPage);
            pagedList.TotalItems.Should().Be(totalItems);
            pagedList.TotalPages.Should().Be(3);
        }

        internal sealed class ConcreteEntity
        {
        }
    }
}

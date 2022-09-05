using eShopCoffe.Catalog.Domain.Commands.ProductCommands;

namespace eShopCoffe.Catalog.Domain.Tests.Commands.ProductCommands
{
    public class RemoveProductCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var command = new RemoveProductCommand(id);

            // Assert
            command.Id.Should().Be(id);
        }
    }
}

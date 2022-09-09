using eShopCoffe.Catalog.Domain.Commands.ProductCommands;

namespace eShopCoffe.Catalog.Domain.Tests.Commands.ProductCommands
{
    public class AddProductCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var name = "Name";
            var description = "Description";
            var quantityAvailable = 0;

            // Act
            var command = new AddProductCommand(name, description, quantityAvailable);

            // Assert
            command.Name.Should().Be(name);
            command.Description.Should().Be(description);
            command.QuantityAvailable.Should().Be(quantityAvailable);
        }
    }
}

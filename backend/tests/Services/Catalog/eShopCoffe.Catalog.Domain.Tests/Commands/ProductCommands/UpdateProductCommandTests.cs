using eShopCoffe.Catalog.Domain.Commands.ProductCommands;

namespace eShopCoffe.Catalog.Domain.Tests.Commands.ProductCommands
{
    public class UpdateProductCommandTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Name";
            var description = "Description";
            var quantityAvailable = 0;

            // Act
            var command = new UpdateProductCommand(id, name, description, quantityAvailable);

            // Assert
            command.Id.Should().Be(id);
            command.Name.Should().Be(name);
            command.Description.Should().Be(description);
            command.QuantityAvailable.Should().Be(quantityAvailable);
        }
    }
}

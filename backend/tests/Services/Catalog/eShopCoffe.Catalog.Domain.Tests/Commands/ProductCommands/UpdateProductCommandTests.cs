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
            var imageUrl = "ImageUrl";
            var quantityAvailable = 0;
            var currencyValue = 1;
            var currencyCode = "CurrencyCode";

            // Act
            var command = new UpdateProductCommand(id, name, description, imageUrl, quantityAvailable, currencyValue, currencyCode);

            // Assert
            command.Id.Should().Be(id);
            command.Name.Should().Be(name);
            command.Description.Should().Be(description);
            command.ImageUrl.Should().Be(imageUrl);
            command.QuantityAvailable.Should().Be(quantityAvailable);
            command.CurrencyValue.Should().Be(currencyValue);
            command.CurrencyCode.Should().Be(currencyCode);
        }
    }
}

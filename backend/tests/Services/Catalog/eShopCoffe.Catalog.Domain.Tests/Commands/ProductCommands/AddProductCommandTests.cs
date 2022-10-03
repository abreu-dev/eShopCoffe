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
            var imageUrl = "ImageUrl";
            var quantityAvailable = 0;
            var currencyValue = 1;
            var currencyCode = "CurrencyCode";

            // Act
            var command = new AddProductCommand(name, description, imageUrl, quantityAvailable, currencyValue, currencyCode);

            // Assert
            command.Name.Should().Be(name);
            command.Description.Should().Be(description);
            command.ImageUrl.Should().Be(imageUrl);
            command.QuantityAvailable.Should().Be(quantityAvailable);
            command.CurrencyValue.Should().Be(currencyValue);
            command.CurrencyCode.Should().Be(currencyCode);
        }
    }
}

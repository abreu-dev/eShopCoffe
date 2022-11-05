using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Catalog.Domain.Tests.Entities
{
    public class ProductDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange
            var name = "Name";
            var description = "Description";
            var imageUrl = "ImageUrl";
            var quantityAvailable = 0;
            var currency = new CurrencyDomain(1, "CurrencyCode");

            // Act
            var productDomain = new ProductDomain(name, description, imageUrl, quantityAvailable, currency);

            // Assert
            productDomain.Name.Should().Be(name);
            productDomain.Description.Should().Be(description);
            productDomain.ImageUrl.Should().Be(imageUrl);
            productDomain.QuantityAvailable.Should().Be(quantityAvailable);
            productDomain.Currency.Should().Be(currency);
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Name";
            var description = "Description";
            var imageUrl = "ImageUrl";
            var quantityAvailable = 0;
            var currency = new CurrencyDomain(1, "CurrencyCode");

            // Act
            var productDomain = new ProductDomain(id, name, description, imageUrl, quantityAvailable, currency);

            // Assert
            productDomain.Id.Should().Be(id);
            productDomain.Name.Should().Be(name);
            productDomain.Description.Should().Be(description);
            productDomain.ImageUrl.Should().Be(imageUrl);
            productDomain.QuantityAvailable.Should().Be(quantityAvailable);
            productDomain.Currency.Should().Be(currency);
        }
    }
}

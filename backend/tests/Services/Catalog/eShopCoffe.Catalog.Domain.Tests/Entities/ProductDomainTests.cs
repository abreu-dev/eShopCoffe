using eShopCoffe.Catalog.Domain.Entities;

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
            var quantityAvailable = 0;

            // Act
            var userDomain = new ProductDomain(name, description, quantityAvailable);

            // Assert
            userDomain.Name.Should().Be(name);
            userDomain.Description.Should().Be(description);
            userDomain.QuantityAvailable.Should().Be(quantityAvailable);
        }
        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Name";
            var description = "Description";
            var quantityAvailable = 0;

            // Act
            var userDomain = new ProductDomain(id, name, description, quantityAvailable);

            // Assert
            userDomain.Id.Should().Be(id);
            userDomain.Name.Should().Be(name);
            userDomain.Description.Should().Be(description);
            userDomain.QuantityAvailable.Should().Be(quantityAvailable);
        }
    }
}

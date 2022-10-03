using eShopCoffe.Catalog.Domain.Entities;

namespace eShopCoffe.Catalog.Domain.Tests.Entities
{
    public class CurrencyDomainTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var value = 1;
            var code = "Code";

            // Act
            var currencyDomain = new CurrencyDomain(value, code);

            // Assert
            currencyDomain.Value.Should().Be(value);
            currencyDomain.Code.Should().Be(code);
        }
    }
}

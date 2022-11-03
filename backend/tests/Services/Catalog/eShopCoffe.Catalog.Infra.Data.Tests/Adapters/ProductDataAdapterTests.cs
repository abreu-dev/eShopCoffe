using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Infra.Data.Adapters;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Catalog.Infra.Data.Tests.Adapters
{
    public class ProductDataAdapterTests
    {
        private readonly ProductDataAdapter _adapter;

        public ProductDataAdapterTests()
        {
            _adapter = new ProductDataAdapter();
        }

        [Fact]
        public void Transform_DomainToData_WhenNull_ShouldReturnNull()
        {
            // Arrange
            ProductDomain? domain = null;

            // Act
            var data = _adapter.Transform(domain);

            // Assert
            data.Should().BeNull();
        }

        [Fact]
        public void Transform_DomainToData_WhenNotNull_ShouldReturnData()
        {
            // Arrange
            var domain = new ProductDomain(Guid.NewGuid(), "Name", "Description", "ImageUrl", 0, new CurrencyDomain(1, "Code"));

            // Act
            var data = _adapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            if (data == null) return;

            data.Id.Should().Be(domain.Id);
            data.Name.Should().Be(domain.Name);
            data.Description.Should().Be(domain.Description);
            data.ImageUrl.Should().Be(domain.ImageUrl);
            data.QuantityAvailable.Should().Be(domain.QuantityAvailable);
            data.CurrencyValue.Should().Be(domain.Currency.Value);
            data.CurrencyCode.Should().Be(domain.Currency.Code);
        }

        [Fact]
        public void Transform_DataToDomain_WhenNull_ShouldReturnNull()
        {
            // Arrange
            ProductData? data = null;

            // Act
            var domain = _adapter.Transform(data);

            // Assert
            domain.Should().BeNull();
        }

        [Fact]
        public void Transform_DataToDomain_WhenNotNull_ShouldReturnDomain()
        {
            // Arrange
            var data = new ProductData()
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Description = "Description",
                ImageUrl = "ImageUrl",
                QuantityAvailable = 0,
                CurrencyValue = 1,
                CurrencyCode = "CurrencyCode"
            };

            // Act
            var domain = _adapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            if (domain == null) return;

            domain.Id.Should().Be(data.Id);
            domain.Name.Should().Be(data.Name);
            domain.Description.Should().Be(data.Description);
            domain.ImageUrl.Should().Be(data.ImageUrl);
            domain.QuantityAvailable.Should().Be(data.QuantityAvailable);
            domain.Currency.Value.Should().Be(data.CurrencyValue);
            domain.Currency.Code.Should().Be(data.CurrencyCode);
        }
    }
}

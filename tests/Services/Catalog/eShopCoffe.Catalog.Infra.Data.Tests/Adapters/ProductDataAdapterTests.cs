using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Infra.Data.Adapters;
using eShopCoffe.Catalog.Infra.Data.Entities;

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
            var domain = new ProductDomain(Guid.NewGuid(), "Name", "Description", 0);

            // Act
            var data = _adapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            data.Id.Should().Be(domain.Id);
            data.Name.Should().Be(domain.Name);
            data.Description.Should().Be(domain.Description);
            data.QuantityAvailable.Should().Be(domain.QuantityAvailable);
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
                QuantityAvailable = 0
            };

            // Act
            var domain = _adapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            domain.Id.Should().Be(data.Id);
            domain.Name.Should().Be(data.Name);
            domain.Description.Should().Be(data.Description);
            domain.QuantityAvailable.Should().Be(data.QuantityAvailable);
        }
    }
}

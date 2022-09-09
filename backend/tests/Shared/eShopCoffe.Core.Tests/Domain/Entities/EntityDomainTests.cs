using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Tests.Domain.Entities
{
    public class EntityDomainTests
    {
        [Fact]
        public void Constructor1_ShouldSetProperties()
        {
            // Arrange & Act
            var entityDomain = new ConcreteEntityDomain();

            // Assert
            entityDomain.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void Constructor2_ShouldSetProperties()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var entityDomain = new ConcreteEntityDomain(id);

            // Assert
            entityDomain.Id.Should().Be(id);
        }

        internal sealed class ConcreteEntityDomain : EntityDomain
        {
            public ConcreteEntityDomain()
            {
            }

            public ConcreteEntityDomain(Guid id) : base(id)
            {
            }
        }
    }
}

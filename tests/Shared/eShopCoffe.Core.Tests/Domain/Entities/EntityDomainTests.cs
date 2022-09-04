using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Tests.Domain.Entities
{
    public class EntityDomainTests
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange & Act
            var entityDomain = new ConcreteEntityDomain();

            // Assert
            entityDomain.Id.Should().NotBeEmpty();
        }

        internal sealed class ConcreteEntityDomain : EntityDomain
        {
        }
    }
}

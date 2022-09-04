using eShopCoffe.Core.Data.Entities;

namespace eShopCoffe.Core.Tests.Data.Entities
{
    public class EntityDataTest
    {
        [Fact]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange & Act
            var entityData = new ConcreteEntityData();

            // Assert
            entityData.Id.Should().NotBeEmpty();
            entityData.CreatedDate.Should().NotBe(default);
            entityData.CreatedBy.Should().Be(EntityData.DefaultUser);
        }

        [Fact]
        public void OnCreate_ShouldSetProperties()
        {
            // Arrange
            var entityData = new ConcreteEntityData();
            var createdDate = DateTime.UtcNow;
            var createdBy = "CreatedBy";

            // Act
            entityData.OnCreate(createdDate, createdBy);

            // Assert
            entityData.CreatedDate.Should().Be(createdDate);
            entityData.CreatedBy.Should().Be(createdBy);
        }

        [Fact]
        public void OnUpdate_ShouldSetProperties()
        {
            // Arrange
            var entityData = new ConcreteEntityData();
            var updatedDate = DateTime.UtcNow;
            var updatedBy = "UpdatedBy";

            // Act
            entityData.OnUpdate(updatedDate, updatedBy);

            // Assert
            entityData.UpdatedDate.Should().Be(updatedDate);
            entityData.UpdatedBy.Should().Be(updatedBy);
        }

        internal sealed class ConcreteEntityData : EntityData
        {
        }
    }
}

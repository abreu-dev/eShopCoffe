using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Data.Adapters.Interfaces;
using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Tests.Data.Adapters
{
    public class DataAdapterTests
    {
        private readonly IDataAdapter<ConcreteEntityDomain, ConcreteEntityData> _adapter;

        public DataAdapterTests()
        {
            _adapter = new ConcreteDataAdapter();
        }

        [Fact]
        public void Transform_ShouldMapDomainListToDataList()
        {
            // Arrange
            var domain = new List<ConcreteEntityDomain>()
            {
                new ConcreteEntityDomain(),
                new ConcreteEntityDomain()
            };

            // Act
            var data = _adapter.Transform(domain);

            // Assert
            data.Should().NotBeNull();
            data.Should().HaveCount(2);
        }

        [Fact]
        public void Transform_ShouldMapDataListToDomainList()
        {
            // Arrange
            var data = new List<ConcreteEntityData>()
            {
                new ConcreteEntityData(),
                new ConcreteEntityData()
            };

            // Act
            var domain = _adapter.Transform(data);

            // Assert
            domain.Should().NotBeNull();
            domain.Should().HaveCount(2);
        }

        internal sealed class ConcreteEntityDomain : EntityDomain
        {
        }

        internal sealed class ConcreteEntityData : EntityData
        {
        }

        internal sealed class ConcreteDataAdapter : DataAdapter<ConcreteEntityDomain, ConcreteEntityData>
        {
            public override ConcreteEntityDomain? Transform(ConcreteEntityData? data)
            {
                return new ConcreteEntityDomain();
            }

            public override ConcreteEntityData? Transform(ConcreteEntityDomain? domain)
            {
                return new ConcreteEntityData();
            }
        }
    }
}

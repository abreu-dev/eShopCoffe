using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Data.Adapters.Interfaces;
using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Core.Tests.Domain.Repositories
{
    public class RepositoryTests
    {
        private IEnumerable<ConcreteEntityData> _entitiesData = new List<ConcreteEntityData>();
        private IEnumerable<ConcreteEntityDomain> _entitiesDomain = new List<ConcreteEntityDomain>();

        private readonly DbSet<ConcreteEntityData> _dbSet;
        private readonly IBaseContext _context;
        private readonly IDataAdapter<ConcreteEntityDomain, ConcreteEntityData> _adapter;

        private readonly IRepository<ConcreteEntityDomain> _repository;

        public RepositoryTests()
        {
            BuildData();

            _dbSet = _entitiesData.AsQueryable().BuildMockDbSet();
            _context = Substitute.For<IBaseContext>();
            _context.GetDbSet<ConcreteEntityData>().Returns(_dbSet);
            _adapter = Substitute.For<IDataAdapter<ConcreteEntityDomain, ConcreteEntityData>>();

            _repository = new ConcreteRepository(_context, _adapter);
        }

        [Fact]
        public void UnitOfWork_ShouldReturnContextAsUnitOfWork()
        {
            // Assert
            _repository.UnitOfWork.Should().Be(_context);
        }

        [Fact]
        public void GetAll_ShouldReturnDomainList()
        {
            // Arrange
            _adapter.Transform(Arg.Is(_dbSet)).Returns(_entitiesDomain);

            // Act
            var result = _repository.GetAll();

            // Assert
            result.Should().BeEquivalentTo(_entitiesDomain);
        }

        [Fact]
        public void GetById_WhenFound_ShouldReturnDomain()
        {
            // Arrange
            _adapter.Transform(Arg.Is(_entitiesData.ElementAt(0))).Returns(_entitiesDomain.ElementAt(0));

            // Act
            var result = _repository.GetById(_entitiesData.ElementAt(0).Id);

            // Assert
            result.Should().Be(_entitiesDomain.ElementAt(0));
        }

        [Fact]
        public void GetById_WhenNotFound_ShouldReturnNull()
        {
            // Act
            var result = _repository.GetById(Guid.NewGuid());

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Add_ShouldTransformAndAddData()
        {
            // Arrange
            var domain = new ConcreteEntityDomain();
            var data = new ConcreteEntityData();
            _adapter.Transform(Arg.Is(domain)).Returns(data);

            // Act
            _repository.Add(domain);

            // Assert
            _context.ReceivedWithAnyArgs(1).AddData(Arg.Any<ConcreteEntityData>());
            _context.Received(1).AddData(Arg.Is(data));
        }

        [Fact]
        public void Add_WhenTransformReturnsNull_ShouldDoNothing()
        {
            // Arrange
            var domain = new ConcreteEntityDomain();
            _adapter.Transform(Arg.Is(domain)).ReturnsNull();

            // Act
            _repository.Add(domain);

            // Assert
            _context.DidNotReceiveWithAnyArgs().AddData(Arg.Any<ConcreteEntityData>());
        }

        [Fact]
        public void Update_ShouldTransformAndUpdateData()
        {
            // Arrange
            var domain = new ConcreteEntityDomain();
            var data = new ConcreteEntityData();
            _adapter.Transform(Arg.Is(domain)).Returns(data);

            // Act
            _repository.Update(domain);

            // Assert
            _context.ReceivedWithAnyArgs(1).UpdateData(Arg.Any<ConcreteEntityData>());
            _context.Received(1).UpdateData(Arg.Is(data));
        }

        [Fact]
        public void Update_WhenTransformReturnsNull_ShouldDoNothing()
        {
            // Arrange
            var domain = new ConcreteEntityDomain();
            _adapter.Transform(Arg.Is(domain)).ReturnsNull();

            // Act
            _repository.Update(domain);

            // Assert
            _context.DidNotReceiveWithAnyArgs().UpdateData(Arg.Any<ConcreteEntityData>());
        }

        [Fact]
        public void Delete_WhenFound_ShouldDeleteData()
        {
            // Act
            _repository.Delete(_entitiesData.ElementAt(0).Id);

            // Assert
            _context.ReceivedWithAnyArgs(1).DeleteData(Arg.Any<ConcreteEntityData>());
            _context.Received(1).DeleteData(Arg.Is(_entitiesData.ElementAt(0)));
        }

        [Fact]
        public void Delete_WhenNotFound_ShouldDoNothing()
        {
            // Act
            _repository.Delete(Guid.NewGuid());

            // Assert
            _context.DidNotReceiveWithAnyArgs().DeleteData(Arg.Any<ConcreteEntityData>());
        }

        [Fact]
        public void Exists_WhenFound_ShouldReturnTrue()
        {
            // Act
            var exists = _repository.Exists(_entitiesData.ElementAt(0).Id);

            // Assert
            exists.Should().BeTrue();
        }

        [Fact]
        public void Exists_WhenNotFound_ShouldReturnFalse()
        {
            // Act
            var exists = _repository.Exists(Guid.NewGuid());

            // Assert
            exists.Should().BeFalse();
        }

        private void BuildData()
        {
            _entitiesData = new List<ConcreteEntityData>()
            {
                new ConcreteEntityData(),
                new ConcreteEntityData(),
                new ConcreteEntityData()
            };

            _entitiesDomain = new List<ConcreteEntityDomain>()
            {
                new ConcreteEntityDomain(),
                new ConcreteEntityDomain(),
                new ConcreteEntityDomain()
            };
        }

        public class ConcreteEntityDomain : EntityDomain
        {
        }

        public class ConcreteEntityData : EntityData
        {
        }

        public class ConcreteDataAdapter : DataAdapter<ConcreteEntityDomain, ConcreteEntityData>
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

        public class ConcreteRepository : Repository<ConcreteEntityDomain, ConcreteEntityData>
        {
            public ConcreteRepository(IBaseContext context, IDataAdapter<ConcreteEntityDomain, ConcreteEntityData> adapter)
                : base(context, adapter)
            {
            }
        }
    }
}

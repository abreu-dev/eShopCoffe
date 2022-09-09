using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Basket.Infra.Data.Repositories;
using eShopCoffe.Core.Data;

namespace eShopCoffe.Basket.Infra.Data.Tests.Repositories
{
    public class BasketRepositoryTests
    {
        private readonly IBaseContext _context;
        private readonly IBasketDataAdapter _adapter;
        private readonly BasketRepository _userRepository;

        public BasketRepositoryTests()
        {
            _context = Substitute.For<IBaseContext>();
            _adapter = Substitute.For<IBasketDataAdapter>();
            _userRepository = new BasketRepository(_context, _adapter);
        }

        [Fact]
        public void GetByUserId_WhenFound_ShouldReturnDomain()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<BasketData>() {
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                },
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId
                }
            };
            _context.Query<BasketData>().Returns(dataList.AsQueryable());

            var domain = new BasketDomain(userId);
            _adapter.Transform(dataList.ElementAt(1)).Returns(domain);

            // Act
            var result = _userRepository.GetByUserId(userId);

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(domain);
        }

        [Fact]
        public void GetByUserId_WhenNotFound_ShouldReturnNull()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var dataList = new List<BasketData>() {
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                }
            };
            _context.Query<BasketData>().Returns(dataList.AsQueryable());

            // Act
            var result = _userRepository.GetByUserId(userId);

            // Assert
            result.Should().BeNull();
        }
    }
}

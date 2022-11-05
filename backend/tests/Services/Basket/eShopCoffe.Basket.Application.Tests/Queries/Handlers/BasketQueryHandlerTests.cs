using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Application.Queries.Handlers;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Basket.Application.Tests.Queries.Handlers
{
    public class BasketQueryHandlerTests
    {
        private readonly IBaseContext _context;
        private readonly ISessionAccessor _sessionAccessor;
        private readonly BasketQueryHandler _basketQueryHandler;

        public BasketQueryHandlerTests()
        {
            _context = Substitute.For<IBaseContext>();
            _sessionAccessor = Substitute.For<ISessionAccessor>();
            _basketQueryHandler = new BasketQueryHandler(_context, _sessionAccessor);
        }

        [Fact]
        public void Handle_BasketQuery_WhenExists_ShouldReturnBasketDto()
        {
            // Arrange
            var basketQuery = new BasketQuery();

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var basketDataList = new List<BasketData>()
            {
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Items = new List<BasketItemData>()
                    {
                        new BasketItemData()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Product = new ProductData()
                            {
                                Name = "ProductName",
                                ImageUrl = "ProductImageUrl",
                                CurrencyCode = "ProductCurrencyCode",
                                CurrencyValue = 1
                            },
                            Amount = 10
                        }
                    }
                },
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Items = new List<BasketItemData>()
                    {
                        new BasketItemData()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Product = new ProductData()
                            {
                                Name = "ProductName",
                                ImageUrl = "ProductImageUrl",
                                CurrencyCode = "ProductCurrencyCode",
                                CurrencyValue = 2
                            },
                            Amount = 15
                        }
                    }
                }
            };
            _context.Query<BasketData>().Returns(basketDataList.AsQueryable());

            // Act
            var result = _basketQueryHandler.Handle(basketQuery).Result;

            // Assert
            result.Should().NotBeNull();

            result.Id.Should().Be(basketDataList.ElementAt(1).Id);
            result.Items.Should().HaveCount(1);
            result.Items.ElementAt(0).Id.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Id);
            result.Items.ElementAt(0).Product.Id.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).ProductId);
            result.Items.ElementAt(0).Product.Name.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Product.Name);
            result.Items.ElementAt(0).Product.ImageUrl.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Product.ImageUrl);
            result.Items.ElementAt(0).Product.CurrencyCode.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Product.CurrencyCode);
            result.Items.ElementAt(0).Product.CurrencyValue.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Product.CurrencyValue);
            result.Items.ElementAt(0).Amount.Should().Be(basketDataList.ElementAt(1).Items.ElementAt(0).Amount);
        }

        [Fact]
        public void Handle_BasketQuery_WhenNotExists_ShouldReturnEmptyBasketDto()
        {
            // Arrange
            var basketQuery = new BasketQuery();

            var userId = Guid.NewGuid();
            _sessionAccessor.UserId.Returns(userId);

            var basketDataList = new List<BasketData>()
            {
                new BasketData()
                {
                    Id = Guid.NewGuid(),
                    UserId = Guid.NewGuid(),
                    Items = new List<BasketItemData>()
                    {
                        new BasketItemData()
                        {
                            Id = Guid.NewGuid(),
                            ProductId = Guid.NewGuid(),
                            Product = new ProductData()
                            {
                                Name = "ProductName"
                            },
                            Amount = 10
                        }
                    }
                }
            };
            _context.Query<BasketData>().Returns(basketDataList.AsQueryable());

            // Act
            var result = _basketQueryHandler.Handle(basketQuery).Result;

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().BeEmpty();
            result.Items.Should().BeEmpty();
        }
    }
}

using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Parameters.Interfaces;
using eShopCoffe.Catalog.Application.Queries.Handlers;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Core.Data;

namespace eShopCoffe.Catalog.Application.Tests.Queries.Handlers
{
    public class ProductQueryHandlerTests
    {
        private readonly IBaseContext _context;
        private readonly ProductQueryHandler _productQueryHandler;

        public ProductQueryHandlerTests()
        {
            _context = Substitute.For<IBaseContext>();
            _productQueryHandler = new ProductQueryHandler(_context);
        }

        [Fact]
        public void Handle_PagedProductsQuery_ShouldReturnPagedList()
        {
            // Arrange
            var productParameters = Substitute.For<IProductParameters>();
            productParameters.Page.Returns(0);
            productParameters.Size.Returns(2);
            var pagedProductsQuery = new PagedProductsQuery(productParameters);

            var productDataList = new List<ProductData>()
            {
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "1 - Name",
                    Description = "1 - Description",
                    ImageUrl = "1 - ImageUrl",
                    QuantityAvailable = 1,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "5 - Name",
                    Description = "5 - Description",
                    ImageUrl = "5 - ImageUrl",
                    QuantityAvailable = 5,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "3 - Name",
                    Description = "3 - Description",
                    ImageUrl = "3 - ImageUrl",
                    QuantityAvailable = 3,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "2 - Name",
                    Description = "2 - Description",
                    ImageUrl = "2 - ImageUrl",
                    QuantityAvailable = 2,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "4 - Name",
                    Description = "4 - Description",
                    ImageUrl = "4 - ImageUrl",
                    QuantityAvailable = 4,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40
                },
            };
            _context.Query<ProductData>().Returns(productDataList.AsQueryable());

            // Act
            var result = _productQueryHandler.Handle(pagedProductsQuery).Result;

            // Assert
            result.TotalItems.Should().Be(5);
            result.Data.Should().HaveCount(2);

            result.Data.ElementAt(0).Id.Should().Be(productDataList.ElementAt(0).Id);
            result.Data.ElementAt(0).Name.Should().Be(productDataList.ElementAt(0).Name);
            result.Data.ElementAt(0).Description.Should().Be(productDataList.ElementAt(0).Description);
            result.Data.ElementAt(0).ImageUrl.Should().Be(productDataList.ElementAt(0).ImageUrl);
            result.Data.ElementAt(0).QuantityAvailable.Should().Be(productDataList.ElementAt(0).QuantityAvailable);
            result.Data.ElementAt(0).CurrencyValue.Should().Be(productDataList.ElementAt(0).CurrencyValue);
            result.Data.ElementAt(0).CurrencyCode.Should().Be(productDataList.ElementAt(0).CurrencyCode);

            result.Data.ElementAt(1).Id.Should().Be(productDataList.ElementAt(3).Id);
            result.Data.ElementAt(1).Name.Should().Be(productDataList.ElementAt(3).Name);
            result.Data.ElementAt(1).Description.Should().Be(productDataList.ElementAt(3).Description);
            result.Data.ElementAt(1).ImageUrl.Should().Be(productDataList.ElementAt(3).ImageUrl);
            result.Data.ElementAt(1).QuantityAvailable.Should().Be(productDataList.ElementAt(3).QuantityAvailable);
            result.Data.ElementAt(1).CurrencyValue.Should().Be(productDataList.ElementAt(3).CurrencyValue);
            result.Data.ElementAt(1).CurrencyCode.Should().Be(productDataList.ElementAt(3).CurrencyCode);
        }

        [Fact]
        public void Handle_ProductDetailQuery_WhenProductFound_ShouldReturnSingleObject()
        {
            // Arrange
            var productDetailQuery = new ProductDetailQuery(Guid.NewGuid());

            var productDataList = new List<ProductData>()
            {
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "1 - Name",
                    Description = "1 - Description",
                    ImageUrl = "1 - ImageUrl",
                    QuantityAvailable = 1,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10
                },
                new ProductData()
                {
                    Id = productDetailQuery.ProductId,
                    Name = "5 - Name",
                    Description = "5 - Description",
                    ImageUrl = "5 - ImageUrl",
                    QuantityAvailable = 5,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "3 - Name",
                    Description = "3 - Description",
                    ImageUrl = "3 - ImageUrl",
                    QuantityAvailable = 3,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "2 - Name",
                    Description = "2 - Description",
                    ImageUrl = "2 - ImageUrl",
                    QuantityAvailable = 2,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "4 - Name",
                    Description = "4 - Description",
                    ImageUrl = "4 - ImageUrl",
                    QuantityAvailable = 4,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40
                },
            };
            _context.Query<ProductData>().Returns(productDataList.AsQueryable());

            // Act
            var result = _productQueryHandler.Handle(productDetailQuery).Result;

            // Assert
            result.Id.Should().Be(productDataList.ElementAt(1).Id);
            result.Name.Should().Be(productDataList.ElementAt(1).Name);
            result.Description.Should().Be(productDataList.ElementAt(1).Description);
            result.ImageUrl.Should().Be(productDataList.ElementAt(1).ImageUrl);
            result.QuantityAvailable.Should().Be(productDataList.ElementAt(1).QuantityAvailable);
            result.CurrencyValue.Should().Be(productDataList.ElementAt(1).CurrencyValue);
            result.CurrencyCode.Should().Be(productDataList.ElementAt(1).CurrencyCode);
        }

        [Fact]
        public void Handle_ProductDetailQuery_WhenProductNotFound_ShouldReturnEmpty()
        {
            // Arrange
            var productDetailQuery = new ProductDetailQuery(Guid.NewGuid());

            var productDataList = new List<ProductData>()
            {
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "1 - Name",
                    Description = "1 - Description",
                    ImageUrl = "1 - ImageUrl",
                    QuantityAvailable = 1,
                    CurrencyCode = "1 - CurrencyCode",
                    CurrencyValue = 10
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "5 - Name",
                    Description = "5 - Description",
                    ImageUrl = "5 - ImageUrl",
                    QuantityAvailable = 5,
                    CurrencyCode = "5 - CurrencyCode",
                    CurrencyValue = 50
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "3 - Name",
                    Description = "3 - Description",
                    ImageUrl = "3 - ImageUrl",
                    QuantityAvailable = 3,
                    CurrencyCode = "3 - CurrencyCode",
                    CurrencyValue = 30
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "2 - Name",
                    Description = "2 - Description",
                    ImageUrl = "2 - ImageUrl",
                    QuantityAvailable = 2,
                    CurrencyCode = "2 - CurrencyCode",
                    CurrencyValue = 20
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "4 - Name",
                    Description = "4 - Description",
                    ImageUrl = "4 - ImageUrl",
                    QuantityAvailable = 4,
                    CurrencyCode = "4 - CurrencyCode",
                    CurrencyValue = 40
                },
            };
            _context.Query<ProductData>().Returns(productDataList.AsQueryable());

            var empty = new ProductDto();

            // Act
            var result = _productQueryHandler.Handle(productDetailQuery).Result;

            // Assert
            result.Id.Should().Be(empty.Id);
            result.Name.Should().Be(empty.Name);
            result.Description.Should().Be(empty.Description);
            result.ImageUrl.Should().Be(empty.ImageUrl);
            result.QuantityAvailable.Should().Be(empty.QuantityAvailable);
            result.CurrencyValue.Should().Be(empty.CurrencyValue);
            result.CurrencyCode.Should().Be(empty.CurrencyCode);
        }
    }
}

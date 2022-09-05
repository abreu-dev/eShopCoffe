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
            var pagedUsersQuery = new PagedProductsQuery(productParameters);

            var productDataList = new List<ProductData>()
            {
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "1 - Name",
                    Description = "1 - Description",
                    QuantityAvailable = 1
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "5 - Name",
                    Description = "5 - Description",
                    QuantityAvailable = 5
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "3 - Name",
                    Description = "3 - Description",
                    QuantityAvailable = 3
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "2 - Name",
                    Description = "2 - Description",
                    QuantityAvailable = 2
                },
                new ProductData()
                {
                    Id = Guid.NewGuid(),
                    Name = "4 - Name",
                    Description = "4 - Description",
                    QuantityAvailable = 4
                },
            };
            _context.Query<ProductData>().Returns(productDataList.AsQueryable());

            // Act
            var result = _productQueryHandler.Handle(pagedUsersQuery).Result;

            // Assert
            result.TotalItems.Should().Be(5);
            result.Data.Should().HaveCount(2);

            result.Data.ElementAt(0).Id.Should().Be(productDataList.ElementAt(0).Id);
            result.Data.ElementAt(0).Name.Should().Be(productDataList.ElementAt(0).Name);
            result.Data.ElementAt(0).Description.Should().Be(productDataList.ElementAt(0).Description);
            result.Data.ElementAt(0).QuantityAvailable.Should().Be(productDataList.ElementAt(0).QuantityAvailable);

            result.Data.ElementAt(1).Id.Should().Be(productDataList.ElementAt(3).Id);
            result.Data.ElementAt(1).Name.Should().Be(productDataList.ElementAt(3).Name);
            result.Data.ElementAt(1).Description.Should().Be(productDataList.ElementAt(3).Description);
            result.Data.ElementAt(1).QuantityAvailable.Should().Be(productDataList.ElementAt(3).QuantityAvailable);
        }
    }
}

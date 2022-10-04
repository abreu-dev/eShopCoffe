using eShopCoffe.Catalog.Infra.Data.Entities;
using eShopCoffe.Catalog.Infra.Data.Seed;
using eShopCoffe.Core.Domain.Repositories.Interfaces;

namespace eShopCoffe.Catalog.Infra.Data.Tests.Seed
{
    public class ProductSeedTests
    {
        [Fact]
        public void ProductSeed_WhenAllProductsFound_ShouldNotCreate()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();

            var productsData = new List<ProductData>();
            for (var index = 0; index < ProductSeed.ProductIdList.Count(); index++)
            {
                productsData.Add(new ProductData()
                {
                    Id = ProductSeed.ProductIdList.ElementAt(index),
                    Name = ProductSeed.ProductNameList.ElementAt(index),
                    Description = ProductSeed.ProductDescriptionList.ElementAt(index),
                    ImageUrl = ProductSeed.ProductImageUrlList.ElementAt(index),
                    QuantityAvailable = ProductSeed.ProductQuantityAvailableList.ElementAt(index),
                    CurrencyValue = ProductSeed.ProductCurrencyValueList.ElementAt(index),
                    CurrencyCode = "BRL"
                });
            }

            repository.Query<ProductData>().Returns(productsData.AsQueryable());

            // Act
            ProductSeed.SeedData(repository);

            // Assert
            repository.Received(1).Query<ProductData>();
            repository.DidNotReceive().Add(Arg.Any<ProductData>());
            repository.UnitOfWork.DidNotReceive().Complete();
        }

        [Fact]
        public void ProductSeed_WhenAtLeastOneProductFound_ShouldCreate()
        {
            // Arrange
            var repository = Substitute.For<IRepository>();

            var productsData = new List<ProductData>();
            for (var index = 0; index < ProductSeed.ProductIdList.Count() - 1; index++)
            {
                productsData.Add(new ProductData()
                {
                    Id = ProductSeed.ProductIdList.ElementAt(index),
                    Name = ProductSeed.ProductNameList.ElementAt(index),
                    Description = ProductSeed.ProductDescriptionList.ElementAt(index),
                    ImageUrl = ProductSeed.ProductImageUrlList.ElementAt(index),
                    QuantityAvailable = ProductSeed.ProductQuantityAvailableList.ElementAt(index),
                    CurrencyValue = ProductSeed.ProductCurrencyValueList.ElementAt(index),
                    CurrencyCode = "BRL"
                });
            }

            repository.Query<ProductData>().Returns(productsData.AsQueryable());

            // Act
            ProductSeed.SeedData(repository);

            // Assert
            repository.Received(1).Query<ProductData>();
            
            repository.Received(1).Add(Arg.Any<ProductData>());
            repository.Received(1).Add(Arg.Is<ProductData>(x => x.Id == ProductSeed.ProductIdList.ElementAt(9)
                                                                && x.Name == ProductSeed.ProductNameList.ElementAt(9)
                                                                && x.Description == ProductSeed.ProductDescriptionList.ElementAt(9)
                                                                && x.ImageUrl == ProductSeed.ProductImageUrlList.ElementAt(9)
                                                                && x.QuantityAvailable == ProductSeed.ProductQuantityAvailableList.ElementAt(9)
                                                                && x.CurrencyValue == ProductSeed.ProductCurrencyValueList.ElementAt(9)
                                                                && x.CurrencyCode == ProductSeed.ProductCurrencyCode));

            repository.UnitOfWork.Received(1).Complete();
        }
    }
}

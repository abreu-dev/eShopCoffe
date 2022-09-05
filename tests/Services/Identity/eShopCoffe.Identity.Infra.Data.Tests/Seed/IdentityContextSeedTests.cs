using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Infra.Data.Entities;
using eShopCoffe.Identity.Infra.Data.Seed;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Infra.Data.Tests.Seed
{
    public class IdentityContextSeedTests
    {
        [Fact]
        public void SeedData_ShouldCallSeeds()
        {
            // Arrange
            var mockContext = Substitute.For<IBaseContext>();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped(x => mockContext);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Act
            IdentityContextSeed.SeedData(serviceProvider);

            // Assert
            mockContext.Received(1).GetDbSet<UserData>();
        }
    }
}

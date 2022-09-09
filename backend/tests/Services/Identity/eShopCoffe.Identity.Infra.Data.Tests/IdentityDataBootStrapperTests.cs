using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Adapters;
using eShopCoffe.Identity.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Identity.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Infra.Data.Tests
{
    public class IdentityDataBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public IdentityDataBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDataServices()
        {
            // Act
            IdentityDataBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(2).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IUserDataAdapter), typeof(UserDataAdapter));
            ValidateService(typeof(IUserRepository), typeof(UserRepository));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Application.Contracts.UserContracts;
using eShopCoffe.Identity.Application.Queries.Handlers;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Application.Tests
{
    public class IdentityApplicationBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public IdentityApplicationBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllApplicationServices()
        {
            // Act
            IdentityApplicationBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(6).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IQueryHandler<PagedUsersQuery, IPagedList<UserDto>>), typeof(UserQueryHandler));
            ValidateService(typeof(ISignInService), typeof(SignInService));
            ValidateService(typeof(ISignUpService), typeof(SignUpService));
            ValidateService(typeof(IPasswordResetService), typeof(PasswordResetService));
            ValidateService(typeof(ITokenService), typeof(TokenService));
            ValidateService(typeof(IHealthService), typeof(HealthService));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

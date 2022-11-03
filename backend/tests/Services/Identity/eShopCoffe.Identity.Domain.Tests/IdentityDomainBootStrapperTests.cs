using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Domain.Events.Handlers;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using eShopCoffe.Identity.Domain.Validators;
using eShopCoffe.Identity.Domain.Validators.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Domain.Tests
{
    public class IdentityDomainBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public IdentityDomainBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllDomainServices()
        {
            // Act
            IdentityDomainBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(3).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IEventHandler<UserSignedInEvent>), typeof(UserEventHandler));
            ValidateService(typeof(ISignUpValidator), typeof(SignUpValidator));
            ValidateService(typeof(IPasswordValidator), typeof(PasswordValidator));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

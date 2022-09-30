using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Domain.Commands.Handlers;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Events.Handlers;
using eShopCoffe.Identity.Domain.Events.UserEvents;
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
            _serviceCollection.Received(4).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(ICommandHandler<AddUserCommand>), typeof(UserCommandHandler));
            ValidateService(typeof(ICommandHandler<UpdateUserCommand>), typeof(UserCommandHandler));
            ValidateService(typeof(ICommandHandler<RemoveUserCommand>), typeof(UserCommandHandler));
            ValidateService(typeof(IEventHandler<UserSignedInEvent>), typeof(UserEventHandler));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

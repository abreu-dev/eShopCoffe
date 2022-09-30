using eShopCoffe.Core.Cryptography;
using eShopCoffe.Core.Cryptography.Interfaces;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Core.Domain.Repositories.Interfaces;
using eShopCoffe.Core.Messaging.Bus;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Dispatchers;
using eShopCoffe.Core.Messaging.Dispatchers.Interfaces;
using eShopCoffe.Core.Messaging.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Security;
using eShopCoffe.Core.Security.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Core.Tests
{
    public class EShopCoffeCoreBootStrapperTests
    {
        private readonly IServiceCollection _serviceCollection;

        public EShopCoffeCoreBootStrapperTests()
        {
            _serviceCollection = Substitute.For<IServiceCollection>();
        }

        [Fact]
        public void ConfigureServices_ShouldConfigureAllCoreServices()
        {
            // Act
            EShopCoffeCoreBootStrapper.ConfigureServices(_serviceCollection);

            // Assert
            _serviceCollection.Received(8).Add(Arg.Any<ServiceDescriptor>());
            ValidateService(typeof(IBus), typeof(MemoryBus));
            ValidateService(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            ValidateService(typeof(IQueryDispatcher), typeof(QueryDispatcher));
            ValidateService(typeof(IEventDispatcher), typeof(EventDispatcher));
            ValidateService(typeof(INotificationHandler), typeof(NotificationHandler));
            ValidateService(typeof(ISessionAccessor), typeof(SessionAccessor));
            ValidateService(typeof(IRepository), typeof(Repository));
            ValidateService(typeof(IPasswordHash), typeof(PasswordHash));
        }

        private void ValidateService(Type interfaceType, Type objectType)
        {
            _serviceCollection.Received(1).Add(Arg.Is<ServiceDescriptor>(x => x.ServiceType == interfaceType && x.ImplementationType == objectType));
        }
    }
}

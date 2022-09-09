using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Domain.Commands.Handlers;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using eShopCoffe.Identity.Domain.Events.Handlers;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Domain
{
    public static class IdentityDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
            EventHandlers(services);
        }

        private static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddUserCommand>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveUserCommand>, UserCommandHandler>();
        }

        private static void EventHandlers(IServiceCollection services)
        {
            services.AddScoped<IEventHandler<UserLoggedInEvent>, UserEventHandler>();
        }
    }
}

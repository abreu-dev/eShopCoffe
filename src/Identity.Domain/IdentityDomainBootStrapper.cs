using Framework.Core.Messaging.Handlers.Interfaces;
using Identity.Domain.Commands.Handlers;
using Identity.Domain.Commands.UserCommands;
using Identity.Domain.Events.Handlers;
using Identity.Domain.Events.UserEvents;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Domain
{
    public static class IdentityDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
            EventHandlers(services);
        }

        public static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddUserCommand>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateUserCommand>, UserCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveUserCommand>, UserCommandHandler>();
        }

        public static void EventHandlers(IServiceCollection services)
        {
            services.AddScoped<IEventHandler<UserLoggedInEvent>, UserEventHandler>();
        }
    }
}

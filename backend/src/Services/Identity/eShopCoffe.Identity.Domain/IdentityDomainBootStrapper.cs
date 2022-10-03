using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Domain.Events.Handlers;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using eShopCoffe.Identity.Domain.Validators;
using eShopCoffe.Identity.Domain.Validators.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Domain
{
    public static class IdentityDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            EventHandlers(services);
            Validators(services);
        }

        private static void EventHandlers(IServiceCollection services)
        {
            services.AddScoped<IEventHandler<UserSignedInEvent>, UserEventHandler>();
        }

        private static void Validators(IServiceCollection services)
        {
            services.AddScoped<ISignUpValidator, SignUpValidator>();
            services.AddScoped<IPasswordValidator, PasswordValidator>();
        }
    }
}

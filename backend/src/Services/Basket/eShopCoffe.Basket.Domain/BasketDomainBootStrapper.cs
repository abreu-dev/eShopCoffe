using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Commands.Handlers;
using eShopCoffe.Basket.Domain.Events.BasketEvents;
using eShopCoffe.Basket.Domain.Events.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Domain
{
    public static class BasketDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
            EventHandlers(services);
        }

        private static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddOrUpdateBasketItemCommand>, BasketCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveBasketItemCommand>, BasketCommandHandler>();
        }

        private static void EventHandlers(IServiceCollection services)
        {
            services.AddScoped<IEventHandler<ClearBasketEvent>, BasketEventHandler>();
        }
    }
}

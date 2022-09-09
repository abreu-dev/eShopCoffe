using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Commands.Handlers;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Domain
{
    public static class BasketDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
        }

        private static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddOrUpdateBasketItemCommand>, BasketCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveBasketItemCommand>, BasketCommandHandler>();
        }
    }
}

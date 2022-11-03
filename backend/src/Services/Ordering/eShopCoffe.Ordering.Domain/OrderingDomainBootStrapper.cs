using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Ordering.Domain.Commands.Handlers;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Domain
{
    public static class OrderingDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
        }

        private static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddOrderCommand>, OrderCommandHandler>();
        }
    }
}

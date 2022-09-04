using eShopCoffe.Catalog.Domain.Commands.Handlers;
using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Domain
{
    public static class CatalogDomainBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommandHandlers(services);
        }

        private static void CommandHandlers(IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<AddProductCommand>, ProductCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateProductCommand>, ProductCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveProductCommand>, ProductCommandHandler>();
        }
    }
}

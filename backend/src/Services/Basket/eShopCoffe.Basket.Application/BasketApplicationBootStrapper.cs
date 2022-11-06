using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Application.Queries.Handlers;
using eShopCoffe.Contracts.Contracts.BasketContracts;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Application
{
    public static class BasketApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
        }

        private static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<BasketQuery, BasketDto>, BasketQueryHandler>();
        }
    }
}

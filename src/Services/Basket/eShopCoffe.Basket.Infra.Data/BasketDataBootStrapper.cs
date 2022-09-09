using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Basket.Infra.Data.Adapters;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Basket.Infra.Data
{
    public static class BasketDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Adapters(services);
            Repositories(services);
        }

        private static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IBasketDataAdapter, BasketDataAdapter>();
            services.AddScoped<IBasketItemDataAdapter, BasketItemDataAdapter>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IBasketRepository, BasketRepository>();
        }
    }
}

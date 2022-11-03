using eShopCoffe.Ordering.Domain.Repositories;
using eShopCoffe.Ordering.Infra.Data.Adapters;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Ordering.Infra.Data
{
    public static class OrderingDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Adapters(services);
            Repositories(services);
        }

        private static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IOrderDataAdapter, OrderDataAdapter>();
            services.AddScoped<IOrderEventDataAdapter, OrderEventDataAdapter>();
            services.AddScoped<IOrderItemDataAdapter, OrderItemDataAdapter>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}

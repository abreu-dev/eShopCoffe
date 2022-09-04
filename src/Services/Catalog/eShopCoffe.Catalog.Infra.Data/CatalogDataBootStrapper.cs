using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Catalog.Infra.Data.Adapters;
using eShopCoffe.Catalog.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Catalog.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Catalog.Infra.Data
{
    public static class CatalogDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Adapters(services);
            Repositories(services);
        }

        private static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IProductDataAdapter, ProductDataAdapter>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}

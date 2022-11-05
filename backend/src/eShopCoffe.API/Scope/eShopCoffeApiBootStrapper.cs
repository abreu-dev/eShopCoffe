using eShopCoffe.Basket.Application;
using eShopCoffe.Basket.Domain;
using eShopCoffe.Basket.Infra.Data;
using eShopCoffe.Catalog.Application;
using eShopCoffe.Catalog.Domain;
using eShopCoffe.Catalog.Infra.Data;
using eShopCoffe.Context;
using eShopCoffe.Core;
using eShopCoffe.Identity.Application;
using eShopCoffe.Identity.Domain;
using eShopCoffe.Identity.Infra.Data;
using eShopCoffe.Ordering.Application;
using eShopCoffe.Ordering.Domain;
using eShopCoffe.Ordering.Infra.Data;

namespace eShopCoffe.API.Scope
{
    public static class EShopCoffeApiBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Shared(services);
            Identity(services);
            Catalog(services);
            Basket(services);
            Ordering(services);
        }

        private static void Shared(IServiceCollection services)
        {
            EShopCoffeCoreBootStrapper.ConfigureServices(services);
            EShopCoffeContextBootStrapper.ConfigureServices(services);
        }

        private static void Identity(IServiceCollection services)
        {
            IdentityDomainBootStrapper.ConfigureServices(services);
            IdentityDataBootStrapper.ConfigureServices(services);
            IdentityApplicationBootStrapper.ConfigureServices(services);
        }

        private static void Catalog(IServiceCollection services)
        {
            CatalogDomainBootStrapper.ConfigureServices(services);
            CatalogDataBootStrapper.ConfigureServices(services);
            CatalogApplicationBootStrapper.ConfigureServices(services);
        }

        private static void Basket(IServiceCollection services)
        {
            BasketDomainBootStrapper.ConfigureServices(services);
            BasketDataBootStrapper.ConfigureServices(services);
            BasketApplicationBootStrapper.ConfigureServices(services);
        }

        private static void Ordering(IServiceCollection services)
        {
            OrderingDomainBootStrapper.ConfigureServices(services);
            OrderingDataBootStrapper.ConfigureServices(services);
            OrderingApplicationBootStrapper.ConfigureServices(services);
        }
    }
}

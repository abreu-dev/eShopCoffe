using eShopCoffe.Catalog.Application;
using eShopCoffe.Catalog.Domain;
using eShopCoffe.Catalog.Infra.Data;
using eShopCoffe.Context;
using eShopCoffe.Core;
using eShopCoffe.Identity.Application;
using eShopCoffe.Identity.Domain;
using eShopCoffe.Identity.Infra.Data;

namespace eShopCoffe.API.Scope
{
    public static class EShopCoffeApiBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Shared(services);
            Identity(services);
            Catalog(services);
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
    }
}

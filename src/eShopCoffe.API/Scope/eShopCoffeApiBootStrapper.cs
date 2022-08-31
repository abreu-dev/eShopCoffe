using eShopCoffe.Context;
using eShopCoffe.Core;
using eShopCoffe.Identity.Application;
using eShopCoffe.Identity.Domain;
using eShopCoffe.Identity.Infra.Data;

namespace eShopCoffe.API.Scope
{
    public static class EShopCoffeApiBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            EShopCoffeCoreBootStrapper.ConfigureServices(services);
            EShopCoffeContextBootStrapper.ConfigureServices(services, configuration);

            IdentityDomainBootStrapper.ConfigureServices(services);
            IdentityDataBootStrapper.ConfigureServices(services);
            IdentityApplicationBootStrapper.ConfigureServices(services);
        }
    }
}

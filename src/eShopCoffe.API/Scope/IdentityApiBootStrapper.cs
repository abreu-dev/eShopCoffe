using eShopCoffe.Core;
using eShopCoffe.Identity.Application;
using eShopCoffe.Identity.Domain;
using eShopCoffe.Identity.Infra.Data;

namespace eShopCoffe.API.Scope
{
    public static class IdentityApiBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            FrameworkCoreBootStrapper.ConfigureServices(services);
            IdentityDomainBootStrapper.ConfigureServices(services);
            IdentityDataBootStrapper.ConfigureServices(services, configuration);
            IdentityApplicationBootStrapper.ConfigureServices(services);
        }
    }
}

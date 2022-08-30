using Framework.Core;
using Identity.Application;
using Identity.Domain;
using Identity.Infra.Data;

namespace Identity.Api.Scope
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

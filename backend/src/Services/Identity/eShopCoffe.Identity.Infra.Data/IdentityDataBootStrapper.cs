using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Adapters;
using eShopCoffe.Identity.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Identity.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Infra.Data
{
    public static class IdentityDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Adapters(services);
            Repositories(services);
        }

        private static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IUserDataAdapter, UserDataAdapter>();
        }

        private static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

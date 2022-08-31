using eShopCoffe.Core.Data;
using eShopCoffe.Identity.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Adapters;
using eShopCoffe.Identity.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Identity.Infra.Data.Context;
using eShopCoffe.Identity.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Infra.Data
{
    public static class IdentityDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Adapters(services);
            Context(services, configuration);
            Repositories(services);
        }

        public static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IUserDataAdapter, UserDataAdapter>();
        }

        public static void Context(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIdentityContext, IdentityContext>();
            services.AddScoped<IBaseContext, IdentityContext>();
            services.AddScoped<IdentityContext>();
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}

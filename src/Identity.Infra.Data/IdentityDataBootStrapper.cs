using Framework.Core.Data;
using Framework.Core.Domain.Repositories;
using Framework.Core.Domain.Repositories.Interfaces;
using Identity.Domain.Repositories;
using Identity.Infra.Data.Adapters;
using Identity.Infra.Data.Adapters.Interfaces;
using Identity.Infra.Data.Context;
using Identity.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Infra.Data
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

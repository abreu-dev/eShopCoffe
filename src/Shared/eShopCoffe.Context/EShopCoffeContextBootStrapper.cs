using eShopCoffe.Context.Context;
using eShopCoffe.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Context
{
    public static class EShopCoffeContextBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Context(services, configuration);
        }

        private static void Context(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EShopCoffeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEShopCoffeContext, EShopCoffeContext>();
            services.AddScoped<IBaseContext, EShopCoffeContext>();
            services.AddScoped<EShopCoffeContext>();
        }
    }
}

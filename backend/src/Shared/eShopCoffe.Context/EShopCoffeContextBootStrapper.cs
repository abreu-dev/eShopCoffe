using eShopCoffe.Context.Context;
using eShopCoffe.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Context
{
    public static class EShopCoffeContextBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Context(services);
        }

        private static void Context(IServiceCollection services)
        {
            services.AddDbContext<EShopCoffeContext>(options => 
                options.UseNpgsql(EShopCoffeContext.CreateConnectionString()));

            services.AddScoped<IEShopCoffeContext, EShopCoffeContext>();
            services.AddScoped<IBaseContext, EShopCoffeContext>();
            services.AddScoped<EShopCoffeContext>();
        }
    }
}

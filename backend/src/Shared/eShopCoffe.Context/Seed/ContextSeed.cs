using eShopCoffe.Catalog.Infra.Data.Seed;
using eShopCoffe.Context.Context;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Context.Seed
{
    public static class ContextSeed
    {
        public static void InitializeDatabase(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EShopCoffeContext>();
                context.Database.Migrate();
            }
        }

        public static void SeedData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EShopCoffeContext>();

                UserSeed.SeedData(new Repository(context));
                ProductSeed.SeedData(new Repository(context));
            }
        }
    }
}

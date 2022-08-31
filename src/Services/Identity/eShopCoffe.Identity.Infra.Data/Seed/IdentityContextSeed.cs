using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Identity.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Infra.Data.Seed
{
    public static class IdentityContextSeed
    {
        public static void SeedData(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<IIdentityContext>();

                UserSeed.SeedData(new Repository(context));
            }
        }
    }
}

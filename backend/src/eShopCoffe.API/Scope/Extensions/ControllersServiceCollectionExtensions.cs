using eShopCoffe.API.Scope.Filters;
using eShopCoffe.API.Scope.Handlers;

namespace eShopCoffe.API.Scope.Extensions
{
    public static class ControllersServiceCollectionExtensions
    {
        public static void AddEShopCoffeControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AuthenticationTokenFilterAttribute));
                options.Filters.Add(typeof(NotificationFilter));
            }).AddNewtonsoftJson();
        }
    }
}

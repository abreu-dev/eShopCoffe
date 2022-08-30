using Identity.Api.Scope.Filters;
using Identity.Api.Scope.Handlers;

namespace Identity.Api.Scope.Extensions
{
    public static class ControllersServiceCollectionExtensions
    {
        public static void AddIdentityControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AuthenticationTokenFilterAttribute));
                options.Filters.Add(typeof(NotificationFilter));
            }).AddNewtonsoftJson();
        }
    }
}

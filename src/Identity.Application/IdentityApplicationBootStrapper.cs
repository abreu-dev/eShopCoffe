using Framework.Core.Data.Pagination.Interfaces;
using Framework.Core.Messaging.Handlers.Interfaces;
using Identity.Application.Contracts.UserContracts;
using Identity.Application.Queries.Handlers;
using Identity.Application.Queries.UserQueries;
using Identity.Application.Services;
using Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class IdentityApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
            Services(services);
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<PagedUsersQuery, IPagedList<UserDto>>, UserQueryHandler>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHealthService, HealthService>();
        }
    }
}

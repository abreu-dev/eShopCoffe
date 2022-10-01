using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Application.Contracts.UserContracts;
using eShopCoffe.Identity.Application.Queries.Handlers;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using eShopCoffe.Identity.Application.Services;
using eShopCoffe.Identity.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCoffe.Identity.Application
{
    public static class IdentityApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
            Services(services);
        }

        private static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<PagedUsersQuery, IPagedList<UserDto>>, UserQueryHandler>();
        }

        private static void Services(IServiceCollection services)
        {
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<ISignUpService, SignUpService>();
            services.AddScoped<IPasswordResetService, PasswordResetService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IHealthService, HealthService>();
        }
    }
}

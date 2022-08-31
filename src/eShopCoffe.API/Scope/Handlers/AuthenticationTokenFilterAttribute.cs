using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Identity.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eShopCoffe.API.Scope.Handlers
{
    public class AuthenticationTokenFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly ITokenService _tokenService;
        private readonly ISessionAccessor _sessionAccessor;

        public AuthenticationTokenFilterAttribute(ITokenService tokenService,
                                                  ISessionAccessor sessionAccessor)
        {
            _tokenService = tokenService;
            _sessionAccessor = sessionAccessor;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (HasFilter(context, typeof(IgnoreAuthenticationTokenFilterAttribute)))
            {
                return;
            }

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var authenticatedUser = _tokenService.ValidateToken(token);
            if (authenticatedUser != null)
            {
                var hasAdminFilter = HasFilter(context, typeof(AdminAuthenticationTokenFilterAttribute));
                if (!hasAdminFilter || authenticatedUser.IsAdmin)
                {
                    _sessionAccessor.Authenticate(authenticatedUser);
                    return;
                }
            }

            context.Result = new UnauthorizedObjectResult(null);
        }

        private bool HasFilter(AuthorizationFilterContext context, Type tokenFilter)
        {
            return context.ActionDescriptor.FilterDescriptors.Any(x => x.Filter.GetType() == tokenFilter);
        }
    }
}

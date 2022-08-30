using Microsoft.AspNetCore.Mvc.Filters;

namespace Identity.Api.Scope.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AdminAuthenticationTokenFilterAttribute : ActionFilterAttribute
    {
    }
}

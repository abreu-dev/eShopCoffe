using Microsoft.AspNetCore.Mvc.Filters;

namespace eShopCoffe.API.Scope.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreAuthenticationTokenFilterAttribute : ActionFilterAttribute
    {
    }
}

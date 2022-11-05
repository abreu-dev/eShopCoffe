using eShopCoffe.API.Scope.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Admin
{
    [Route("admin")]
    [AdminAuthenticationTokenFilter]
    public abstract class AdminsController : BaseController
    {
    }
}

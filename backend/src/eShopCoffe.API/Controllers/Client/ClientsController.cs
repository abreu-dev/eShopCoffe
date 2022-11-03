using eShopCoffe.API.Scope.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Client
{
    [Route("clients")]
    [ClientAuthenticationTokenFilterAttribute]
    public abstract class ClientsController : BaseController
    {
    }
}

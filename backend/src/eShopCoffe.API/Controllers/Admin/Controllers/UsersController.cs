using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Identity.Application.Contracts.UserContracts;
using eShopCoffe.Identity.Application.Parameters;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Admin.Controllers
{
    [Route("admin/users")]
    public class UsersController : AdminsController
    {
        private readonly IBus _bus;

        public UsersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserParameters parameters)
        {
            var query = new PagedUsersQuery(parameters);
            return Ok(await _bus.Query<PagedUsersQuery, IPagedList<UserDto>>(query));
        }
    }
}

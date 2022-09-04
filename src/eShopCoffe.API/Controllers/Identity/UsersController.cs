using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Identity.Application.Contracts.UserContracts;
using eShopCoffe.Identity.Application.Parameters;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Identity
{
    [AdminAuthenticationTokenFilter]
    public class UsersController : BaseController
    {
        private readonly IBus _bus;

        public UsersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("identity/users")]
        public async Task<IActionResult> Get([FromQuery] UserParameters parameters)
        {
            var query = new PagedUsersQuery(parameters);
            return Ok(await _bus.Query<PagedUsersQuery, IPagedList<UserDto>>(query, CancellationToken.None));
        }

        [HttpPost]
        [Route("identity/users")]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            var command = new AddUserCommand(creationDto.Login, creationDto.Password);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }

        [HttpPut]
        [Route("identity/users/{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UserCreationDto creationDto)
        {
            var command = new UpdateUserCommand(id, creationDto.Login, creationDto.Password);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete]
        [Route("identity/users/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveUserCommand(id);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }
    }
}

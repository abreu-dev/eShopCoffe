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
    public class UsersController : IdentityController
    {
        private readonly IBus _bus;

        public UsersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get([FromQuery] UserParameters parameters)
        {
            var query = new PagedUsersQuery(parameters);
            return Ok(await _bus.Query<PagedUsersQuery, IPagedList<UserDto>>(query));
        }

        [HttpPost]
        [Route("users")]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            var command = new AddUserCommand(creationDto.Username, creationDto.Email, creationDto.Password);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpPut]
        [Route("users/{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UserCreationDto creationDto)
        {
            var command = new UpdateUserCommand(id, creationDto.Username, creationDto.Email, creationDto.Password);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("users/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveUserCommand(id);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

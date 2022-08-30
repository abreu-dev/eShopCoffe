using Framework.Core.Data.Pagination.Interfaces;
using Framework.Core.Messaging.Bus.Interfaces;
using Identity.Api.Scope.Handlers;
using Identity.Application.Contracts.UserContracts;
using Identity.Application.Parameters;
using Identity.Application.Queries.UserQueries;
using Identity.Domain.Commands.UserCommands;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [AdminAuthenticationTokenFilterAttribute]
    public class UsersController : BaseController
    {
        private readonly IBus _bus;

        public UsersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("api/users")]
        public async Task<IActionResult> Get([FromQuery] UserParameters parameters)
        {
            var query = new PagedUsersQuery(parameters);
            return Ok(await _bus.Query<PagedUsersQuery, IPagedList<UserDto>>(query, CancellationToken.None));
        }

        [HttpPost]
        [Route("api/users")]
        public async Task<IActionResult> Post([FromBody] UserCreationDto creationDto)
        {
            var command = new AddUserCommand(creationDto.Login, creationDto.Password);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }

        [HttpPut]
        [Route("api/users/{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] UserCreationDto creationDto)
        {
            var command = new UpdateUserCommand(id, creationDto.Login, creationDto.Password);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }

        [HttpDelete]
        [Route("api/users/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveUserCommand(id);
            await _bus.Command(command, CancellationToken.None);
            return NoContent();
        }
    }
}

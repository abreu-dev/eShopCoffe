using Framework.Core.Messaging.Bus.Interfaces;
using Identity.Api.Scope.Handlers;
using Identity.Api.Scope.Responses;
using Identity.Application.Contracts.SessionContracts;
using Identity.Application.Services.Interfaces;
using Identity.Domain.Events.UserEvents;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [IgnoreAuthenticationTokenFilter]
    public class SessionController : BaseController
    {
        private readonly Identity.Application.Services.Interfaces.IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly IBus _bus;

        public SessionController(Identity.Application.Services.Interfaces.IAuthenticationService authenticationService,
                                 ITokenService tokenService,
                                 IBus bus)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
            _bus = bus;
        }

        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = _authenticationService.Authenticate(loginDto.Login, loginDto.Password);

            if (result.HasSucceed && result.Item != null)
            {
                var loginResult = new LoginResultDto()
                {
                    Token = _tokenService.GenerateAuthenticationToken(result.Item),
                    User = new LoginResultUserDto()
                    {
                        Id = result.Item.Id,
                        Login = result.Item.Login,
                        IsAdmin = result.Item.IsAdmin
                    }
                };

                await _bus.Event(new UserLoggedInEvent(loginResult.User.Id), CancellationToken.None);

                return Ok(loginResult);
            }

            return BadRequest(new BadRequestResponse("api/login")
            {
                Errors = new List<BadRequestResponseError>()
                {
                    new BadRequestResponseError(result.ErrorCode, result.ErrorMessage)
                }
            });
        }
    }
}

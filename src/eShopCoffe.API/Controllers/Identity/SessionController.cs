using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.API.Scope.Responses;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Identity.Application.Contracts.SessionContracts;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Identity
{
    [IgnoreAuthenticationTokenFilter]
    public class SessionController : IdentityController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;
        private readonly IBus _bus;

        public SessionController(IAuthenticationService authenticationService,
                                 ITokenService tokenService,
                                 IBus bus)
        {
            _authenticationService = authenticationService;
            _tokenService = tokenService;
            _bus = bus;
        }

        [HttpPost]
        [Route("login")]
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

            return BadRequest(new BadRequestResponse("login")
            {
                Errors = new List<BadRequestResponseError>()
                {
                    new BadRequestResponseError(result.ErrorCode ?? "", result.ErrorMessage ?? "")
                }
            });
        }
    }
}

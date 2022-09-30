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
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            var result = _authenticationService.Authenticate(signInDto.Username, signInDto.Password);

            if (result.HasSucceed && result.Item != null)
            {
                var signInResultDto = new SignInResultDto()
                {
                    Token = _tokenService.GenerateAuthenticationToken(result.Item),
                    User = new SignInResultUserDto()
                    {
                        Id = result.Item.Id,
                        Username = result.Item.Username,
                        IsAdmin = result.Item.IsAdmin
                    }
                };

                await _bus.Event(new UserSignedInEvent(signInResultDto.User.Id));

                return Ok(signInResultDto);
            }

            return BadRequest(new BadRequestResponse("sign-in")
            {
                Errors = new List<BadRequestResponseError>()
                {
                    new BadRequestResponseError(result.ErrorCode ?? "", result.ErrorMessage ?? "")
                }
            });
        }
    }
}

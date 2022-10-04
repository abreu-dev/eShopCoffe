using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.API.Scope.Responses;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Validators.Interfaces;
using eShopCoffe.Identity.Application.Contracts.SessionContracts;
using eShopCoffe.Identity.Application.Services.Interfaces;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Domain.Events.UserEvents;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Identity
{
    [IgnoreAuthenticationTokenFilter]
    public class SessionController : IdentityController
    {
        private readonly ISignInService _signInService;
        private readonly ISignUpService _signUpService;
        private readonly IPasswordResetService _passwordResetService;
        private readonly ITokenService _tokenService;
        private readonly IBus _bus;

        public SessionController(
            ISignInService signInService,
            ISignUpService signUpService,
            IPasswordResetService passwordResetService,
            ITokenService tokenService,
            IBus bus)
        {
            _signInService = signInService;
            _signUpService = signUpService;
            _passwordResetService = passwordResetService;
            _tokenService = tokenService;
            _bus = bus;
        }

        [HttpPost]
        [Route("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] SignInDto signInDto)
        {
            var result = _signInService.SignIn(signInDto.Username, signInDto.Password);

            if (result.HasSucceed && result.Item != null)
            {
                return await GetSignInResult(result);
            }

            return GetBadRequestResult(result, "sign-in");
        }

        [HttpPost]
        [Route("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var result = _signUpService.SignUp(signUpDto.Username, signUpDto.Email, signUpDto.Password);

            if (result.HasSucceed && result.Item != null)
            {
                return await GetSignInResult(result);
            }

            return GetBadRequestResult(result, "sign-up");
        }

        [HttpPost]
        [Route("password-reset:request")]
        public IActionResult RequestPasswordReset([FromBody] RequestPasswordResetDto requestPasswordResetDto)
        {
            _passwordResetService.RequestPasswordReset(requestPasswordResetDto.Username);
            return NoContent();
        }

        [HttpPost]
        [Route("password-reset:confirm")]
        public IActionResult ConfirmPasswordReset([FromBody] ConfirmPasswordResetDto confirmPasswordResetDto)
        {
            var result = _passwordResetService.ConfirmPasswordReset(
                confirmPasswordResetDto.Username,
                confirmPasswordResetDto.NewPassword,
                confirmPasswordResetDto.PasswordResetCode);

            if (result.HasSucceed)
            {
                return NoContent();
            }

            return GetBadRequestResult(result, "password-reset/confirm");
        }

        private async Task<IActionResult> GetSignInResult(IResult<UserDomain> result)
        {
            var signInResultDto = new SignInResultDto()
            {
                Token = _tokenService.GenerateAuthenticationToken(result.Item),
                User = new SignInResultUserDto()
                {
                    Id = result.Item.Id,
                    Username = result.Item.Username,
                    Email = result.Item.Email,
                    IsAdmin = result.Item.IsAdmin
                }
            };

            await _bus.Event(new UserSignedInEvent(signInResultDto.User.Id));

            return Ok(signInResultDto);
        }

        private IActionResult GetBadRequestResult(Core.Validators.Interfaces.IResult result, string instance)
        {
            return BadRequest(new BadRequestResponse(instance)
            {
                Errors = new List<BadRequestResponseError>()
                {
                    new BadRequestResponseError(result.ErrorCode ?? "", result.ErrorMessage ?? "")
                }
            });
        }
    }
}

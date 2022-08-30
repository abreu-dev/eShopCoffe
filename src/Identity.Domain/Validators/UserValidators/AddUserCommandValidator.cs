using FluentValidation;
using Framework.Core.Validators;
using Identity.Domain.Commands.UserCommands;

namespace Identity.Domain.Validators.UserValidators
{
    public class AddUserCommandValidator : CommandValidator<AddUserCommand>
    {
        public AddUserCommandValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

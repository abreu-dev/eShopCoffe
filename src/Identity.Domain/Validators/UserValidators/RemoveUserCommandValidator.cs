using FluentValidation;
using Framework.Core.Validators;
using Identity.Domain.Commands.UserCommands;

namespace Identity.Domain.Validators.UserValidators
{
    public class RemoveUserCommandValidator : CommandValidator<RemoveUserCommand>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}

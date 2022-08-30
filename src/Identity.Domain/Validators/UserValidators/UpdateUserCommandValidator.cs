using FluentValidation;
using Framework.Core.Validators;
using Identity.Domain.Commands.UserCommands;

namespace Identity.Domain.Validators.UserValidators
{
    public class UpdateUserCommandValidator : CommandValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Login)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

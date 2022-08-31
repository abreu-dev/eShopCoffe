using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using FluentValidation;

namespace eShopCoffe.Identity.Domain.Validators.UserValidators
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

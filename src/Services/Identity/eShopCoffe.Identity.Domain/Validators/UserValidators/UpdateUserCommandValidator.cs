using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using FluentValidation;

namespace eShopCoffe.Identity.Domain.Validators.UserValidators
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

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

            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}

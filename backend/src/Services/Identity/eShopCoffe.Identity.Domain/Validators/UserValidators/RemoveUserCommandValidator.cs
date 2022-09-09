using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Commands.UserCommands;
using FluentValidation;

namespace eShopCoffe.Identity.Domain.Validators.UserValidators
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

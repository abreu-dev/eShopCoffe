using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Validators;
using FluentValidation;

namespace eShopCoffe.Catalog.Domain.Validators.ProductValidators
{
    public class RemoveProductCommandValidator : CommandValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}

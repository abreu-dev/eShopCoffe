using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Validators;
using FluentValidation;

namespace eShopCoffe.Catalog.Domain.Validators.ProductValidators
{
    public class AddProductCommandValidator : CommandValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.ImageUrl)
                .NotEmpty();

            RuleFor(x => x.QuantityAvailable)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CurrencyCode)
                .NotEmpty();

            RuleFor(x => x.CurrencyValue)
                .GreaterThan(0);
        }
    }
}

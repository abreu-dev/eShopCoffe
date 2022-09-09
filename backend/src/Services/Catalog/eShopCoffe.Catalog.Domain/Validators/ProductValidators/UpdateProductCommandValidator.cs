using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Validators;
using FluentValidation;

namespace eShopCoffe.Catalog.Domain.Validators.ProductValidators
{
    public class UpdateProductCommandValidator : CommandValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.QuantityAvailable)
                .GreaterThanOrEqualTo(0);
        }
    }
}

using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Core.Validators;
using FluentValidation;

namespace eShopCoffe.Basket.Domain.Validators.BasketValidators
{
    public class AddOrUpdateBasketItemCommandValidator : CommandValidator<AddOrUpdateBasketItemCommand>
    {
        public AddOrUpdateBasketItemCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();

            RuleFor(x => x.Amount)
               .GreaterThan(0);
        }
    }
}

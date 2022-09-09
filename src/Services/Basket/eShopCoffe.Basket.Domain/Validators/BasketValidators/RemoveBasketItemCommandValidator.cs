using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Core.Validators;
using FluentValidation;

namespace eShopCoffe.Basket.Domain.Validators.BasketValidators
{
    public class RemoveBasketItemCommandValidator : CommandValidator<RemoveBasketItemCommand>
    {
        public RemoveBasketItemCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty();
        }
    }
}

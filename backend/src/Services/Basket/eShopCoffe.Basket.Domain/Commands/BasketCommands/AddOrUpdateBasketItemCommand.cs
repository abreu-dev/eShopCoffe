using eShopCoffe.Basket.Domain.Validators.BasketValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Basket.Domain.Commands.BasketCommands
{
    public class AddOrUpdateBasketItemCommand : ValidatableCommand<AddOrUpdateBasketItemCommand>
    {
        public Guid ProductId { get; private set; }
        public int Amount { get; private set; }

        public AddOrUpdateBasketItemCommand(Guid productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }

        protected override CommandValidator<AddOrUpdateBasketItemCommand> GetValidator()
        {
            return new AddOrUpdateBasketItemCommandValidator();
        }
    }
}

using eShopCoffe.Basket.Domain.Validators.BasketValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Basket.Domain.Commands.BasketCommands
{
    public class RemoveBasketItemCommand : ValidatableCommand<RemoveBasketItemCommand>
    {
        public Guid ProductId { get; private set; }

        public RemoveBasketItemCommand(Guid productId)
        {
            ProductId = productId;
        }

        protected override CommandValidator<RemoveBasketItemCommand> GetValidator()
        {
            return new RemoveBasketItemCommandValidator();
        }
    }
}

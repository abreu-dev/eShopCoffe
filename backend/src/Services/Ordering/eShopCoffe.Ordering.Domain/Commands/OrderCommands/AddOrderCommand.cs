using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;
using eShopCoffe.Ordering.Domain.Validators.OrderValidators;

namespace eShopCoffe.Ordering.Domain.Commands.OrderCommands
{
    public class AddOrderCommand : ValidatableCommand<AddOrderCommand>
    {
        public string Cep { get; private set; }
        public string? Number { get; private set; }
        public string PaymentMethod { get; private set; }
        public IEnumerable<OrderItem> Items { get; private set; }
        public bool ClearBasket { get; private set; }

        public AddOrderCommand(string cep,
                               string? number,
                               string paymentMethod,
                               IEnumerable<OrderItem> items,
                               bool clearBasket)
        {
            Cep = cep;
            Number = number;
            PaymentMethod = paymentMethod;
            Items = items;
            ClearBasket = clearBasket;
        }

        protected override CommandValidator<AddOrderCommand> GetValidator()
        {
            return new AddOrderCommandValidator();
        }

        public class OrderItem
        {
            public Guid ProductId { get; private set; }
            public int Amount { get; private set; }

            public OrderItem(Guid productId, int amount)
            {
                ProductId = productId;
                Amount = amount;
            }
        }
    }
}

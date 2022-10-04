using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Catalog.Domain.Commands.ProductCommands
{
    public class AddProductCommand : ValidatableCommand<AddProductCommand>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int QuantityAvailable { get; private set; }
        public decimal CurrencyValue { get; private set; }
        public string CurrencyCode { get; private set; }

        public AddProductCommand(
            string name,
            string description,
            string imageUrl,
            int quantityAvailable,
            decimal currencyValue,
            string currencyCode)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            QuantityAvailable = quantityAvailable;
            CurrencyValue = currencyValue;
            CurrencyCode = currencyCode;
        }

        protected override CommandValidator<AddProductCommand> GetValidator()
        {
            return new AddProductCommandValidator();
        }
    }
}

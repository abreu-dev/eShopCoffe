using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Catalog.Domain.Commands.ProductCommands
{
    public class UpdateProductCommand : ValidatableCommand<UpdateProductCommand>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImageUrl { get; private set; }
        public int QuantityAvailable { get; private set; }
        public decimal CurrencyValue { get; private set; }
        public string CurrencyCode { get; private set; }

        public UpdateProductCommand(
            Guid id,
            string name,
            string description,
            string imageUrl,
            int quantityAvailable,
            decimal currencyValue,
            string currencyCode)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            QuantityAvailable = quantityAvailable;
            CurrencyValue = currencyValue;
            CurrencyCode = currencyCode;
        }

        protected override CommandValidator<UpdateProductCommand> GetValidator()
        {
            return new UpdateProductCommandValidator();
        }
    }
}

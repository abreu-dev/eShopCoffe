using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Catalog.Domain.Commands.ProductCommands
{
    public class AddProductCommand : ValidatableCommand<AddProductCommand>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int QuantityAvailable { get; private set; }

        public AddProductCommand(string name, string description, int quantityAvailable)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
        }

        protected override CommandValidator<AddProductCommand> GetValidator()
        {
            return new AddProductCommandValidator();
        }
    }
}

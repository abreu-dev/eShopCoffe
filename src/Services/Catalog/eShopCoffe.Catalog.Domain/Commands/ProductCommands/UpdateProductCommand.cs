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
        public int QuantityAvailable { get; private set; }

        public UpdateProductCommand(Guid id, string name, string description, int quantityAvailable)
        {
            Id = id;
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
        }

        protected override CommandValidator<UpdateProductCommand> GetValidator()
        {
            return new UpdateProductCommandValidator();
        }
    }
}

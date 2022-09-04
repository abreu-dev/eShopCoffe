using eShopCoffe.Catalog.Domain.Validators.ProductValidators;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;

namespace eShopCoffe.Catalog.Domain.Commands.ProductCommands
{
    public class RemoveProductCommand : ValidatableCommand<RemoveProductCommand>
    {
        public Guid Id { get; private set; }

        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public override CommandValidator<RemoveProductCommand> GetValidator()
        {
            return new RemoveProductCommandValidator();
        }
    }
}

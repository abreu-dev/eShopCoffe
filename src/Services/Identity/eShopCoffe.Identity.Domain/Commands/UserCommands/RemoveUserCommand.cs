using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Validators;
using eShopCoffe.Identity.Domain.Validators.UserValidators;

namespace eShopCoffe.Identity.Domain.Commands.UserCommands
{
    public class RemoveUserCommand : ValidatableCommand<RemoveUserCommand>
    {
        public Guid Id { get; private set; }

        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public override CommandValidator<RemoveUserCommand> GetValidator()
        {
            return new RemoveUserCommandValidator();
        }
    }
}

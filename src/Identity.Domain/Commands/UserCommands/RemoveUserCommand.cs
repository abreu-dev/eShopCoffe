using Framework.Core.Messaging.Requests;
using Framework.Core.Validators;
using Identity.Domain.Validators.UserValidators;

namespace Identity.Domain.Commands.UserCommands
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

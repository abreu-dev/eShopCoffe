using FluentValidation;
using Framework.Core.Messaging.Requests;

namespace Framework.Core.Validators
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : Command
    {
    }
}

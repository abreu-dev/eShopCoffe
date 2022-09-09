using eShopCoffe.Core.Messaging.Requests;
using FluentValidation;

namespace eShopCoffe.Core.Validators
{
    public abstract class CommandValidator<TCommand> : AbstractValidator<TCommand>
        where TCommand : Command
    {
    }
}

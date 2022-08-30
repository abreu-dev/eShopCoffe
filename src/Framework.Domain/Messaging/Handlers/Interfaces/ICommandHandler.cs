using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Handlers.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken = default);
    }
}

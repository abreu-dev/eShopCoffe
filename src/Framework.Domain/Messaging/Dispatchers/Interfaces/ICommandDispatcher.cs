using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Dispatchers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}

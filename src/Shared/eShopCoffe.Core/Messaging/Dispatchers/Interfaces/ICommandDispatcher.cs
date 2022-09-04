using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Dispatchers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}

using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Dispatchers.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default)
            where TQuery : IQuery<TResult>
            where TResult : IQueryResult;
    }
}

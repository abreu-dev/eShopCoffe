using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Handlers.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> where TResult : IQueryResult
    {
        Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
    }
}

using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Messaging.Requests
{
    public abstract class Query<TResult> : IQuery<TResult> where TResult : IQueryResult
    {
    }
}

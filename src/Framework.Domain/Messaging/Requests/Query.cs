using Framework.Core.Messaging.Requests.Interfaces;

namespace Framework.Core.Messaging.Requests
{
    public abstract class Query<TResult> : IQuery<TResult> where TResult : IQueryResult
    {
    }
}

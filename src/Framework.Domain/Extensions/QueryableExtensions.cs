using System.Linq.Dynamic.Core;

namespace Framework.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string statement)
        {
            return source.OrderBy(statement);
        }
    }
}

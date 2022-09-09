using System.Linq.Dynamic.Core;

namespace eShopCoffe.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IOrderedQueryable<T> Order<T>(this IQueryable<T> source, string statement)
        {
            return source.OrderBy(statement);
        }
    }
}

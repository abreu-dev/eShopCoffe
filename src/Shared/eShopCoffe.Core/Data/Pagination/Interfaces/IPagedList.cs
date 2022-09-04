using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Core.Data.Pagination.Interfaces
{
    public interface IPagedList<T> : IQueryResult
    {
        IEnumerable<T> Data { get; set; }
        int CurrentPage { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
    }
}

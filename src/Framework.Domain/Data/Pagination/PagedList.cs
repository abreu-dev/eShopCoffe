using Framework.Core.Data.Pagination.Interfaces;

namespace Framework.Core.Data.Pagination
{
    public class PagedList<T> : IPagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PagedList(IEnumerable<T> items, int totalItems, int currentPage, int pageSize)
        {
            Data = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        }
    }
}

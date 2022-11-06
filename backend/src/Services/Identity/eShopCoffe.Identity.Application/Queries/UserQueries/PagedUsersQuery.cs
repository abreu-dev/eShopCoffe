using eShopCoffe.Contracts.Contracts.UserContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Requests.Interfaces;
using eShopCoffe.Identity.Application.Parameters.Interfaces;

namespace eShopCoffe.Identity.Application.Queries.UserQueries
{
    public class PagedUsersQuery : IQuery<IPagedList<UserDto>>
    {
        public IUserParameters Parameters { get; private set; }

        public PagedUsersQuery(IUserParameters parameters)
        {
            Parameters = parameters;
        }
    }
}

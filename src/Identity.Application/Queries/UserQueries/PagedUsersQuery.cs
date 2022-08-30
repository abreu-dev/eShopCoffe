using Framework.Core.Data.Pagination.Interfaces;
using Framework.Core.Messaging.Requests.Interfaces;
using Identity.Application.Contracts.UserContracts;
using Identity.Application.Parameters.Interfaces;

namespace Identity.Application.Queries.UserQueries
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

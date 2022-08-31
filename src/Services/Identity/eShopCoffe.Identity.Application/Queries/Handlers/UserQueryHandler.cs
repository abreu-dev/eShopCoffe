using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Pagination;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Extensions;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Identity.Application.Contracts.UserContracts;
using eShopCoffe.Identity.Application.Queries.UserQueries;
using eShopCoffe.Identity.Infra.Data.Entities;

namespace eShopCoffe.Identity.Application.Queries.Handlers
{
    public class UserQueryHandler :
        IQueryHandler<PagedUsersQuery, IPagedList<UserDto>>
    {
        private readonly IBaseContext _context;

        public UserQueryHandler(IBaseContext context)
        {
            _context = context;
        }

        public Task<IPagedList<UserDto>> Handle(PagedUsersQuery query, CancellationToken cancellationToken = default)
        {
            var source = _context.Query<UserData>();

            source = string.IsNullOrEmpty(query.Parameters.Order) ? source.OrderBy(p => p.Login) : source.Order(query.Parameters.Order);

            var totalItems = source.Count();

            var dtos = (from user in source
                        select new UserDto()
                        {
                            Id = user.Id,
                            Login = user.Login
                        })
                        .Skip(query.Parameters.Page * query.Parameters.Size)
                        .Take(query.Parameters.Size)
                        .ToList();

            IPagedList<UserDto> pagedList = new PagedList<UserDto>(dtos, totalItems, query.Parameters.Page, query.Parameters.Size);
            return Task.FromResult(pagedList);
        }
    }
}

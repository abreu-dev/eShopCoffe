using Framework.Core.Data.Pagination;
using Framework.Core.Data.Pagination.Interfaces;
using Framework.Core.Extensions;
using Framework.Core.Messaging.Handlers.Interfaces;
using Identity.Application.Contracts.UserContracts;
using Identity.Application.Queries.UserQueries;
using Identity.Infra.Data.Context;
using Identity.Infra.Data.Entities;

namespace Identity.Application.Queries.Handlers
{
    public class UserQueryHandler :
        IQueryHandler<PagedUsersQuery, IPagedList<UserDto>>
    {
        private readonly IIdentityContext _context;

        public UserQueryHandler(IIdentityContext context)
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

using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Pagination;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Extensions;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Ordering.Application.Contracts;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using eShopCoffe.Ordering.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace eShopCoffe.Ordering.Application.Queries.Handlers
{
    public class OrderQueryHandler :
        IQueryHandler<AdminPagedOrdersQuery, IPagedList<OrderDto>>,
        IQueryHandler<PagedOrdersQuery, IPagedList<OrderDto>>,
        IQueryHandler<OrderDetailQuery, OrderDto>
    {
        private readonly IBaseContext _context;
        private readonly ISessionAccessor _sessionAccessor;

        public OrderQueryHandler(IBaseContext context, ISessionAccessor sessionAccessor)
        {
            _context = context;
            _sessionAccessor = sessionAccessor;
        }

        private Task<IPagedList<OrderDto>> GetPagedOrders(IQueryable<OrderData> source, int page, int size)
        {
            var totalItems = source.Count();

            var dtos = (from order in source
                        select new OrderDto()
                        {
                            Id = order.Id,
                            Address = new OrderAddressDto()
                            {
                                Cep = order.Cep,
                                Number = order.Number
                            },
                            PaymentMethod = order.PaymentMethod.GetEnumDisplayName(),
                            CurrencyValue = order.CurrencyValue,
                            CurrencyCode = order.CurrencyCode,
                            Status = order.Status.GetEnumDisplayName(),
                            CreatedDate = order.CreatedDate,
                            Events = order.Events.OrderBy(x => x.Date).Select(@event => new OrderEventDto
                            {
                                Status = @event.Status.GetEnumDisplayName(),
                                Date = @event.Date
                            }),
                            Items = order.Items.Select(item => new OrderItemDto()
                            {
                                Name = item.Product.Name,
                                ImageUrl = item.Product.ImageUrl,
                                Amount = item.Amount,
                                CurrencyCode = item.CurrencyCode,
                                CurrencyValue = item.CurrencyValue
                            })
                        })
                        .Skip(page * size)
                        .Take(size)
                        .ToList();

            IPagedList<OrderDto> pagedList = new PagedList<OrderDto>(dtos, totalItems, page, size);
            return Task.FromResult(pagedList);
        }

        public Task<IPagedList<OrderDto>> Handle(AdminPagedOrdersQuery query, CancellationToken cancellationToken = default)
        {
            var source = _context.Query<OrderData>()
                .Include(x => x.Events)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .OrderByDescending(p => p.CreatedDate);

            return GetPagedOrders(source, query.Parameters.Page, query.Parameters.Size);
        }

        public Task<IPagedList<OrderDto>> Handle(PagedOrdersQuery query, CancellationToken cancellationToken = default)
        {
            var source = _context.Query<OrderData>()
                .Include(x => x.Events)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .Where(x => x.UserId == _sessionAccessor.UserId);

            source = source.OrderByDescending(p => p.CreatedDate);

            return GetPagedOrders(source, query.Parameters.Page, query.Parameters.Size);
        }

        public Task<OrderDto> Handle(OrderDetailQuery query, CancellationToken cancellationToken = default)
        {
            var order = _context.Query<OrderData>()
                .Include(x => x.Events)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.UserId == _sessionAccessor.UserId && x.Id == query.OrderId);

            if (order == null)
                return Task.FromResult(new OrderDto());

            var orderDto = new OrderDto()
            {
                Id = order.Id,
                Address = new OrderAddressDto()
                {
                    Cep = order.Cep,
                    Number = order.Number
                },
                PaymentMethod = order.PaymentMethod.GetEnumDisplayName(),
                CurrencyValue = order.CurrencyValue,
                CurrencyCode = order.CurrencyCode,
                Status = order.Status.GetEnumDisplayName(),
                CreatedDate = order.CreatedDate,
                Events = order.Events.OrderBy(x => x.Date).Select(@event => new OrderEventDto
                {
                    Status = @event.Status.GetEnumDisplayName(),
                    Date = @event.Date
                }),
                Items = order.Items.Select(item => new OrderItemDto()
                {
                    Name = item.Product.Name,
                    ImageUrl = item.Product.ImageUrl,
                    Amount = item.Amount,
                    CurrencyCode = item.CurrencyCode,
                    CurrencyValue = item.CurrencyValue
                })
            };

            return Task.FromResult(orderDto);
        }
    }
}

using eShopCoffe.Basket.Application.Contracts.BasketContracts;
using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Basket.Application.Queries.Handlers
{
    public class BasketQueryHandler :
        IQueryHandler<BasketQuery, BasketDto>
    {
        private readonly IBaseContext _context;
        private readonly ISessionAccessor _sessionAccessor;

        public BasketQueryHandler(IBaseContext context,
                                  ISessionAccessor sessionAccessor)
        {
            _context = context;
            _sessionAccessor = sessionAccessor;
        }

        public Task<BasketDto> Handle(BasketQuery query, CancellationToken cancellationToken = default)
        {
            var source = _context.Query<BasketData>()
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .SingleOrDefault(x => x.UserId == _sessionAccessor.UserId);

            var dto = new BasketDto();

            if (source == null)
            {
                return Task.FromResult(dto);
            }

            dto.Id = source.Id;
            dto.Items = (from basketItem in source.Items
                         select new BasketItemDto()
                         {
                             Id = basketItem.Id,
                             Product = new BasketItemProductDto()
                             {
                                 Id = basketItem.ProductId,
                                 Name = basketItem.Product.Name
                             },
                             Amount = basketItem.Amount
                         }).ToList();

            return Task.FromResult(dto);
        }
    }
}

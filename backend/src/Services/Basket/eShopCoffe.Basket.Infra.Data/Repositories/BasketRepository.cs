using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Basket.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Basket.Infra.Data.Entities;
using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Basket.Infra.Data.Repositories
{
    public class BasketRepository : Repository<BasketDomain, BasketData>, IBasketRepository
    {
        public BasketRepository(IBaseContext context, IBasketDataAdapter adapter) : base(context, adapter)
        {
        }

        public override void Update(BasketDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data == null) return;

            var existingParent = _context.Query<BasketData>()
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == domain.Id);

            if (existingParent != null)
            {
                _context.GetDbEntry(existingParent).CurrentValues.SetValues(data);

                foreach (var existingChild in existingParent.Items.ToList())
                {
                    if (!data.Items.Any(c => c.Id == existingChild.Id))
                        _context.GetDbSet<BasketItemData>().Remove(existingChild);
                }

                foreach (var childModel in data.Items)
                {
                    var existingChild = existingParent.Items
                        .SingleOrDefault(c => c.Id == childModel.Id && c.Id != Guid.Empty);

                    if (existingChild != null)
                        _context.GetDbEntry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        existingParent.Items.Add(childModel);
                        _context.GetDbEntry(childModel).State = EntityState.Added;
                    }
                }
            }
        }

        public BasketDomain? GetByUserId(Guid userId)
        {
            var data = _context.Query<BasketData>()
                .AsNoTracking()
                .Include(x => x.Items)
                .FirstOrDefault(x => x.UserId == userId);

            if (data == null) return null;

            return _adapter.Transform(data);
        }
    }
}

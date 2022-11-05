using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Domain.Repositories;
using eShopCoffe.Identity.Domain.Entities;
using eShopCoffe.Identity.Infra.Data.Entities;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Repositories;
using eShopCoffe.Ordering.Infra.Data.Adapters.Interfaces;
using eShopCoffe.Ordering.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Ordering.Infra.Data.Repositories
{
    public class OrderRepository : Repository<OrderDomain, OrderData>, IOrderRepository
    {
        public OrderRepository(IBaseContext context, IOrderDataAdapter adapter) : base(context, adapter)
        {
        }

        public override OrderDomain? GetById(Guid id)
        {
            var data = _dbSet.AsNoTracking()
                .Include(x => x.Events)
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.Id == id);

            if (data == null) return null;

            return _adapter.Transform(data);
        }

        public override void Update(OrderDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data == null) return;

            var existingParent = _context.Query<OrderData>()
                .Include(x => x.Events)
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == domain.Id);

            if (existingParent != null)
            {
                _context.UpdateData(data);

                foreach (var existingChild in existingParent.Items.ToList())
                {
                    if (!data.Items.Any(c => c.Id == existingChild.Id))
                        _context.GetDbSet<OrderItemData>().Remove(existingChild);
                }

                foreach (var existingChild in existingParent.Events.ToList())
                {
                    if (!data.Events.Any(c => c.Id == existingChild.Id))
                        _context.GetDbSet<OrderEventData>().Remove(existingChild);
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

                foreach (var childModel in data.Events)
                {
                    var existingChild = existingParent.Events
                        .SingleOrDefault(c => c.Id == childModel.Id && c.Id != Guid.Empty);

                    if (existingChild != null)
                        _context.GetDbEntry(existingChild).CurrentValues.SetValues(childModel);
                    else
                    {
                        existingParent.Events.Add(childModel);
                        _context.GetDbEntry(childModel).State = EntityState.Added;
                    }
                }
            }
        }
    }
}

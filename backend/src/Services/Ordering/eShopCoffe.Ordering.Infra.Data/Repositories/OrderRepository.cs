using eShopCoffe.Core.Data;
using eShopCoffe.Core.Domain.Repositories;
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

                UpdateOrderItems(existingParent.Items, data.Items);
                UpdateOrderEvents(existingParent.Events, data.Events);
            }
        }

        private void UpdateOrderItems(ICollection<OrderItemData> existingItems, ICollection<OrderItemData> items)
        {
            foreach (var existingItem in existingItems)
            {
                if (!items.Any(c => c.Id == existingItem.Id))
                    _context.GetDbSet<OrderItemData>().Remove(existingItem);
            }

            foreach (var item in items)
            {
                var existingItem = existingItems
                    .SingleOrDefault(c => c.Id == item.Id && c.Id != Guid.Empty);

                if (existingItem != null)
                    _context.GetDbEntry(existingItem).CurrentValues.SetValues(item);
                else
                {
                    existingItems.Add(item);
                    _context.GetDbEntry(item).State = EntityState.Added;
                }
            }
        }

        private void UpdateOrderEvents(ICollection<OrderEventData> existingEvents, ICollection<OrderEventData> events)
        {
            foreach (var existingEvent in existingEvents)
            {
                if (!events.Any(c => c.Id == existingEvent.Id))
                    _context.GetDbSet<OrderEventData>().Remove(existingEvent);
            }

            foreach (var @event in events)
            {
                var existingEvent = existingEvents
                    .SingleOrDefault(c => c.Id == @event.Id && c.Id != Guid.Empty);

                if (existingEvent != null)
                    _context.GetDbEntry(existingEvent).CurrentValues.SetValues(@event);
                else
                {
                    existingEvents.Add(@event);
                    _context.GetDbEntry(@event).State = EntityState.Added;
                }
            }
        }
    }
}
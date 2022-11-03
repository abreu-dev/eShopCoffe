using eShopCoffe.Basket.Domain.Events.BasketEvents;
using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;

namespace eShopCoffe.Basket.Domain.Events.Handlers
{
    public class BasketEventHandler :
        IEventHandler<ClearBasketEvent>
    {
        private readonly IBasketRepository _basketRepository;

        public BasketEventHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public Task Handle(ClearBasketEvent @event, CancellationToken cancellationToken = default)
        {
            var existingBasket = _basketRepository.GetByUserId(@event.UserId);
            if (existingBasket != null)
            {
                _basketRepository.Delete(existingBasket.Id);
                _basketRepository.UnitOfWork.Complete();
            }

            return Task.CompletedTask;
        }
    }
}

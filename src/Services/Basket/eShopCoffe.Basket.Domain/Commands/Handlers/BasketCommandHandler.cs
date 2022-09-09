using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Domain.Repositories;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Security.Interfaces;

namespace eShopCoffe.Basket.Domain.Commands.Handlers
{
    public class BasketCommandHandler : 
        ICommandHandler<AddOrUpdateBasketItemCommand>,
        ICommandHandler<RemoveBasketItemCommand>
    {
        private readonly IBus _bus;
        private readonly IBasketRepository _basketRepository;
        private readonly ISessionAccessor _sessionAccessor;

        public BasketCommandHandler(IBus bus,
                                    IBasketRepository basketRepository,
                                    ISessionAccessor sessionAccessor)
        {
            _bus = bus;
            _basketRepository = basketRepository;
            _sessionAccessor = sessionAccessor;
        }

        public async Task Handle(AddOrUpdateBasketItemCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var existingBasket = _basketRepository.GetByUserId(_sessionAccessor.UserId);
            if (existingBasket == null)
            {
                var newBasket = new BasketDomain(_sessionAccessor.UserId);
                newBasket.AddOrUpdateItem(command.ProductId, command.Amount);
                _basketRepository.Add(newBasket);
            }
            else
            {
                existingBasket.AddOrUpdateItem(command.ProductId, command.Amount);
                _basketRepository.Update(existingBasket);
            }

            _basketRepository.UnitOfWork.Complete();
        }

        public async Task Handle(RemoveBasketItemCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var existingBasket = _basketRepository.GetByUserId(_sessionAccessor.UserId);
            if (existingBasket != null)
            {
                existingBasket.RemoveItemByProductId(command.ProductId);

                _basketRepository.Update(existingBasket);
                _basketRepository.UnitOfWork.Complete();
            }
        }
    }
}

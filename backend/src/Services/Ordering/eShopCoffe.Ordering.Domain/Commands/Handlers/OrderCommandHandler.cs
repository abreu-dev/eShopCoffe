using eShopCoffe.Basket.Domain.Events.BasketEvents;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Extensions;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using eShopCoffe.Ordering.Domain.Entities;
using eShopCoffe.Ordering.Domain.Enums;
using eShopCoffe.Ordering.Domain.Repositories;

namespace eShopCoffe.Ordering.Domain.Commands.Handlers
{
    public class OrderCommandHandler :
        ICommandHandler<AddOrderCommand>
    {
        private readonly IBus _bus;
        private readonly ISessionAccessor _sessionAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(IBus bus,
                                   ISessionAccessor sessionAccessor,
                                   IProductRepository productRepository,
                                   IOrderRepository orderRepository)
        {
            _bus = bus;
            _sessionAccessor = sessionAccessor;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task Handle(AddOrderCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var newOrder = new OrderDomain(
                _sessionAccessor.UserId,
                new AddressDomain(command.Cep, command.Number),
                EnumExtensions.GetEnumValueFromName<PaymentMethod>(command.PaymentMethod));
            
            foreach (var item in command.Items)
            {
                var product = _productRepository.GetById(item.ProductId);

                if (product == null)
                {
                    await _bus.Notification(new Notification("ProductNotFound", "Product was not found."), cancellationToken);
                    return;
                }

                newOrder.AddItem(item.ProductId, item.Amount, product.Currency);
            }

            _orderRepository.Add(newOrder);
            _orderRepository.UnitOfWork.Complete();

            if (command.ClearBasket)
            {
                await _bus.Event(new ClearBasketEvent(_sessionAccessor.UserId), cancellationToken);
            }
        }
    }
}

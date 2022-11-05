using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Catalog.Domain.Entities;
using eShopCoffe.Catalog.Domain.Repositories;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Core.Messaging.Handlers.Interfaces;
using eShopCoffe.Core.Messaging.Requests;

namespace eShopCoffe.Catalog.Domain.Commands.Handlers
{
    public class ProductCommandHandler :
        ICommandHandler<AddProductCommand>,
        ICommandHandler<UpdateProductCommand>,
        ICommandHandler<RemoveProductCommand>
    {
        private readonly IBus _bus;
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IBus bus,
                                     IProductRepository productRepository)
        {
            _bus = bus;
            _productRepository = productRepository;
        }

        public async Task Handle(AddProductCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var product = new ProductDomain(command.Name, command.Description, command.ImageUrl, command.QuantityAvailable, new CurrencyDomain(command.CurrencyValue, command.CurrencyCode));

            _productRepository.Add(product);
            _productRepository.UnitOfWork.Complete();
        }

        public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            var product = new ProductDomain(command.Id, command.Name, command.Description, command.ImageUrl, command.QuantityAvailable, new CurrencyDomain(command.CurrencyValue, command.CurrencyCode));

            _productRepository.Update(product);
            _productRepository.UnitOfWork.Complete();
        }

        public async Task Handle(RemoveProductCommand command, CancellationToken cancellationToken = default)
        {
            if (!command.IsValid())
            {
                foreach (var error in command.ValidationResult.Errors)
                {
                    await _bus.Notification(new Notification(error.ErrorCode, error.ErrorMessage), cancellationToken);
                }
                return;
            }

            _productRepository.Delete(command.Id);
            _productRepository.UnitOfWork.Complete();
        }
    }
}

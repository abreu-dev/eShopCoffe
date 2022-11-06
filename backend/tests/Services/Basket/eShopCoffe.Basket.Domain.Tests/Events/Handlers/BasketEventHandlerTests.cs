using eShopCoffe.Basket.Domain.Entities;
using eShopCoffe.Basket.Domain.Events.BasketEvents;
using eShopCoffe.Basket.Domain.Events.Handlers;
using eShopCoffe.Basket.Domain.Repositories;

namespace eShopCoffe.Basket.Domain.Tests.Events.Handlers
{
    public class BasketEventHandlerTests
    {
        private readonly IBasketRepository _basketRepository;
        private readonly BasketEventHandler _handler;

        public BasketEventHandlerTests()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _handler = new BasketEventHandler(_basketRepository);
        }

        [Fact]
        public void Handle_ClearBasketEvent_WhenFoundBasket_ShouldDeleteIt()
        {
            // Arrange
            var @event = new ClearBasketEvent(Guid.NewGuid());

            var existingBasket = new BasketDomain(@event.UserId);
            _basketRepository.GetByUserId(@event.UserId).Returns(existingBasket);

            // Act
            _handler.Handle(@event);

            // Assert
            _basketRepository.Received(1).Delete(existingBasket.Id);
            _basketRepository.UnitOfWork.Received(1).Complete();
        }

        [Fact]
        public void Handle_ClearBasketEvent_WhenNotFoundBasket_ShouldDoNothing()
        {
            // Arrange
            var @event = new ClearBasketEvent(Guid.NewGuid());

            _basketRepository.GetByUserId(@event.UserId).ReturnsNull();

            // Act
            _handler.Handle(@event);

            // Assert
            _basketRepository.DidNotReceive().Delete(Arg.Any<Guid>());
            _basketRepository.UnitOfWork.DidNotReceive().Complete();
        }
    }
}

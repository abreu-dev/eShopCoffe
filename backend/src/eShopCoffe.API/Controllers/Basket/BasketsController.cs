using eShopCoffe.Basket.Application.Contracts.BasketContracts;
using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Basket
{
    public class BasketsController : BaseController
    {
        private readonly IBus _bus;

        public BasketsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("baskets")]
        public async Task<IActionResult> Get()
        {
            var query = new BasketQuery();
            return Ok(await _bus.Query<BasketQuery, BasketDto>(query));
        }

        [HttpPost]
        [Route("baskets")]
        public async Task<IActionResult> Post([FromBody] BasketItemCreationDto creationDto)
        {
            var command = new AddOrUpdateBasketItemCommand(creationDto.ProductId, creationDto.Amount);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("baskets/{productId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid productId)
        {
            var command = new RemoveBasketItemCommand(productId);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

using eShopCoffe.Basket.Application.Contracts.BasketContracts;
using eShopCoffe.Basket.Application.Queries.BasketQueries;
using eShopCoffe.Basket.Domain.Commands.BasketCommands;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Client.Controllers
{
    [Route("baskets")]
    public class BasketsController : ClientsController
    {
        private readonly IBus _bus;

        public BasketsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new BasketQuery();
            return Ok(await _bus.Query<BasketQuery, BasketDto>(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BasketItemCreationDto creationDto)
        {
            var command = new AddOrUpdateBasketItemCommand(creationDto.ProductId, creationDto.Amount, creationDto.Increase);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid productId)
        {
            var command = new RemoveBasketItemCommand(productId);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

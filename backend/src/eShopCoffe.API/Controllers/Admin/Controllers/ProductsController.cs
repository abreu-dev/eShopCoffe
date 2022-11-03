using eShopCoffe.API.Controllers.Client;
using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Admin.Controllers
{
    [Route("admin/products")]
    public class ProductsController : AdminsController
    {
        private readonly IBus _bus;

        public ProductsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreationDto creationDto)
        {
            var command = new AddProductCommand(
                creationDto.Name,
                creationDto.Description,
                creationDto.ImageUrl,
                creationDto.QuantityAvailable,
                creationDto.CurrencyValue,
                creationDto.CurrencyCode);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProductCreationDto creationDto)
        {
            var command = new UpdateProductCommand(
                id,
                creationDto.Name,
                creationDto.Description,
                creationDto.ImageUrl,
                creationDto.QuantityAvailable,
                creationDto.CurrencyValue,
                creationDto.CurrencyCode);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveProductCommand(id);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

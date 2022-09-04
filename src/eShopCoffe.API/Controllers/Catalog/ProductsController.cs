using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Parameters;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Catalog.Domain.Commands.ProductCommands;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Catalog
{
    public class ProductsController : BaseController
    {
        private readonly IBus _bus;

        public ProductsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("catalog/products")]
        public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
        {
            var query = new PagedProductsQuery(parameters);
            return Ok(await _bus.Query<PagedProductsQuery, IPagedList<ProductDto>>(query));
        }

        [HttpPost]
        [Route("catalog/products")]
        [AdminAuthenticationTokenFilter]
        public async Task<IActionResult> Post([FromBody] ProductCreationDto creationDto)
        {
            var command = new AddProductCommand(creationDto.Name, creationDto.Description, creationDto.QuantityAvailable);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpPut]
        [Route("catalog/products/{id}")]
        [AdminAuthenticationTokenFilter]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProductCreationDto creationDto)
        {
            var command = new UpdateProductCommand(id, creationDto.Name, creationDto.Description, creationDto.QuantityAvailable);
            await _bus.Command(command);
            return NoContent();
        }

        [HttpDelete]
        [Route("catalog/products/{id}")]
        [AdminAuthenticationTokenFilter]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveProductCommand(id);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

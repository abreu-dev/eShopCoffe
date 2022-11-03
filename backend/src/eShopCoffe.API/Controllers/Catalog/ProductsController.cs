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
    public class ProductsController : CatalogController
    {
        private readonly IBus _bus;

        public ProductsController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        [Route("products")]
        [IgnoreAuthenticationTokenFilter]
        public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
        {
            var query = new PagedProductsQuery(parameters);
            return Ok(await _bus.Query<PagedProductsQuery, IPagedList<ProductDto>>(query));
        }

        [HttpGet]
        [Route("products/{id}")]
        [IgnoreAuthenticationTokenFilter]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new ProductDetailQuery(id);
            return Ok(await _bus.Query<ProductDetailQuery, ProductDto>(query));
        }

        [HttpPost]
        [Route("products")]
        [AdminAuthenticationTokenFilter]
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
        [Route("products/{id}")]
        [AdminAuthenticationTokenFilter]
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
        [Route("products/{id}")]
        [AdminAuthenticationTokenFilter]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new RemoveProductCommand(id);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

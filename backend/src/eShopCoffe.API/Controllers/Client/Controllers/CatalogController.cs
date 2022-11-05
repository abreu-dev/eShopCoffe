using eShopCoffe.API.Scope.Handlers;
using eShopCoffe.Catalog.Application.Contracts.ProductContracts;
using eShopCoffe.Catalog.Application.Parameters;
using eShopCoffe.Catalog.Application.Queries.ProductQueries;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Client.Controllers
{
    [Route("catalog")]
    [IgnoreAuthenticationTokenFilter]
    public class CatalogController : ClientsController
    {
        private readonly IBus _bus;

        public CatalogController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductParameters parameters)
        {
            var query = new PagedProductsQuery(parameters);
            return Ok(await _bus.Query<PagedProductsQuery, IPagedList<ProductDto>>(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new ProductDetailQuery(id);
            return Ok(await _bus.Query<ProductDetailQuery, ProductDto>(query));
        }
    }
}

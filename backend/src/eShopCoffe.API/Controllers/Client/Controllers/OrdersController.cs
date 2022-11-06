using eShopCoffe.Contracts.Contracts.OrderingContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Ordering.Application.Parameters;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using eShopCoffe.Ordering.Domain.Commands.OrderCommands;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Client.Controllers
{
    [Route("orders")]
    public class OrdersController : ClientsController
    {
        private readonly IBus _bus;

        public OrdersController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderParameters parameters)
        {
            var query = new PagedOrdersQuery(parameters);
            return Ok(await _bus.Query<PagedOrdersQuery, IPagedList<OrderDto>>(query));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new OrderDetailQuery(id);
            return Ok(await _bus.Query<OrderDetailQuery, OrderDto>(query));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderCreationDto creationDto)
        {
            var items = new List<AddOrderCommand.OrderItem>();
            foreach (var item in creationDto.Items)
            {
                items.Add(new AddOrderCommand.OrderItem(item.ProductId, item.Amount));
            }

            var command = new AddOrderCommand(
                creationDto.Address.Cep,
                creationDto.Address.Number,
                creationDto.PaymentMethod,
                items,
                creationDto.ClearBasket);
            await _bus.Command(command);
            return NoContent();
        }
    }
}

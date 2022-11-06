using eShopCoffe.Contracts.Contracts.OrderingContracts;
using eShopCoffe.Core.Data.Pagination.Interfaces;
using eShopCoffe.Core.Messaging.Bus.Interfaces;
using eShopCoffe.Ordering.Application.Parameters;
using eShopCoffe.Ordering.Application.Queries.OrderQueries;
using eShopCoffe.Ordering.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eShopCoffe.API.Controllers.Admin.Controllers
{
    [Route("admin/manage-orders")]
    public class OrdersManagementController : AdminsController
    {
        private readonly IBus _bus;
        private readonly IOrderRepository _orderRepository;

        public OrdersManagementController(IBus bus, IOrderRepository orderRepository)
        {
            _bus = bus;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] OrderParameters parameters)
        {
            var query = new AdminPagedOrdersQuery(parameters);
            return Ok(await _bus.Query<AdminPagedOrdersQuery, IPagedList<OrderDto>>(query));
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderManagementDto dto)
        {
            var order = _orderRepository.GetById(dto.OrderId);

            if (order != null)
            {
                order.ToNextStatus();
                _orderRepository.Update(order);
                _orderRepository.UnitOfWork.Complete();
            }

            return NoContent();
        }
    }
}
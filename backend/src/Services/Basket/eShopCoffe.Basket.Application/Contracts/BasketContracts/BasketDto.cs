using eShopCoffe.Core.Messaging.Requests.Interfaces;

namespace eShopCoffe.Basket.Application.Contracts.BasketContracts
{
    public class BasketDto : IQueryResult
    {
        public Guid Id { get; set; }
        public ICollection<BasketItemDto> Items { get; set; } = new List<BasketItemDto>();
    }
}

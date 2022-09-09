namespace eShopCoffe.Basket.Application.Contracts.BasketContracts
{
    public class BasketItemDto
    {
        public Guid Id { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public BasketItemProductDto Product { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int Amount { get; set; }
    }
}

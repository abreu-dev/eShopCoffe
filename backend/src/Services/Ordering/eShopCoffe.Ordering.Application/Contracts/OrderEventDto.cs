namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderEventDto
    {
        public string Status { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}

namespace eShopCoffe.Ordering.Application.Contracts
{
    public class OrderAddressDto
    {
        public string Cep { get; set; } = string.Empty;
        public string? Number { get; set; }
    }
}

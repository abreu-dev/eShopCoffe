namespace eShopCoffe.Catalog.Domain.Entities
{
    public class CurrencyDomain
    {
        public decimal Value { get; private set; }
        public string Code { get; private set; }

        public CurrencyDomain(decimal value, string code)
        {
            Value = value;
            Code = code;
        }
    }
}

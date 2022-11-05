namespace eShopCoffe.Core.Domain.Entities
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

        public void SetCode(string code)
        {
            Code = code;
        }

        public void SetValue(decimal value)
        {
            Value = value;
        }
    }
}

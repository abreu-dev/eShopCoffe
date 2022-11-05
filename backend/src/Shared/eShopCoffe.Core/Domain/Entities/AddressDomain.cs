namespace eShopCoffe.Core.Domain.Entities
{
    public class AddressDomain
    {
        public string Cep { get; private set; }
        public string? Number { get; private set; }

        public AddressDomain(string cep, string? number)
        {
            Cep = cep;
            Number = number;
        }
    }
}

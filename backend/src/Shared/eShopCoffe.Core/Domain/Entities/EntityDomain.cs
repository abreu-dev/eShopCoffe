namespace eShopCoffe.Core.Domain.Entities
{
    public abstract class EntityDomain
    {
        public Guid Id { get; private set; }

        protected EntityDomain()
        {
            Id = Guid.NewGuid();
        }

        protected EntityDomain(Guid id)
        {
            Id = id;
        }
    }
}

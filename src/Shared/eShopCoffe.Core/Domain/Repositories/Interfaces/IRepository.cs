using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;

namespace eShopCoffe.Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntityDomain> where TEntityDomain : EntityDomain
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TEntityDomain> GetAll();
        TEntityDomain? GetById(Guid id);

        void Add(TEntityDomain domain);
        void Update(TEntityDomain domain);
        void Delete(Guid id);

        bool Exists(Guid id);
    }

    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TBaseData> Query<TBaseData>() where TBaseData : EntityData;

        void Add<TBaseData>(TBaseData data) where TBaseData : EntityData;
    }
}

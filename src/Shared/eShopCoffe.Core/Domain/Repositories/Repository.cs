using eShopCoffe.Core.Data;
using eShopCoffe.Core.Data.Adapters;
using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Domain.Entities;
using eShopCoffe.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eShopCoffe.Core.Domain.Repositories
{
    public abstract class Repository<TEntityDomain, TEntityData> : IRepository<TEntityDomain>
        where TEntityDomain : EntityDomain
        where TEntityData : EntityData
    {
        protected readonly IBaseContext _context;
        protected readonly IDataAdapter<TEntityDomain, TEntityData> _adapter;

        private readonly DbSet<TEntityData> _dbSet;

        protected Repository(IBaseContext context,
                             IDataAdapter<TEntityDomain, TEntityData> adapter)
        {
            _context = context;
            _adapter = adapter;

            _dbSet = _context.GetDbSet<TEntityData>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public IEnumerable<TEntityDomain> GetAll()
        {
            return _adapter.Transform(_dbSet.AsNoTracking());
        }

        public TEntityDomain? GetById(Guid id)
        {
            var data = _dbSet.AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (data == null) return null;

            return _adapter.Transform(data);
        }

        public virtual void Add(TEntityDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data != null) _context.AddData(data);
        }

        public virtual void Update(TEntityDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data != null) _context.UpdateData(data);
        }

        public virtual void Delete(Guid id)
        {
            var data = _dbSet.FirstOrDefault(x => x.Id == id);

            if (data != null) _context.DeleteData(data);
        }

        public bool Exists(Guid id)
        {
            return _dbSet.AsNoTracking().Any(x => x.Id == id);
        }
    }

    public class Repository : IRepository
    {
        private readonly IBaseContext _context;

        public Repository(IBaseContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public IQueryable<TBaseData> Query<TBaseData>() where TBaseData : EntityData
        {
            return _context.GetDbSet<TBaseData>().AsQueryable();
        }

        public void Add<TBaseData>(TBaseData data) where TBaseData : EntityData
        {
            _context.AddData(data);
        }
    }
}

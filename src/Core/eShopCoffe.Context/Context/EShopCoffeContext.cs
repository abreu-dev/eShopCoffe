using eShopCoffe.Catalog.Infra.Data;
using eShopCoffe.Core.Data.Entities;
using eShopCoffe.Core.Security.Interfaces;
using eShopCoffe.Identity.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eShopCoffe.Context.Context
{
    public class EShopCoffeContext : DbContext, IEShopCoffeContext
    {
        protected readonly ISessionAccessor _sessionAccessor;

        public EShopCoffeContext(DbContextOptions<EShopCoffeContext> options,
                                 ISessionAccessor sessionAccessor) : base(options)
        {
            _sessionAccessor = sessionAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDataBootStrapper).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogDataBootStrapper).Assembly);
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : EntityData
        {
            return Set<TEntity>();
        }

        public EntityEntry<TEntity> GetDbEntry<TEntity>(TEntity data) where TEntity : EntityData
        {
            return Entry(data);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : EntityData
        {
            return Set<TEntity>().AsQueryable();
        }

        public void AddData<TEntity>(TEntity data) where TEntity : EntityData
        {
            data.OnCreate(GetDate(), GetLogin());
            Add(data);
        }

        public void UpdateData<TEntity>(TEntity data) where TEntity : EntityData
        {
            var existingData = GetDbSet<TEntity>().SingleOrDefault(x => x.Id == data.Id);

            if (existingData != null)
            {
                GetDbEntry(existingData).CurrentValues.SetValues(data);
                UpdateState(existingData);
            }
        }

        public void UpdateState<TEntity>(TEntity data) where TEntity : EntityData
        {
            var entry = GetDbEntry(data);
            data.OnUpdate(GetDate(), GetLogin());

            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedDate).IsModified = false;
            }
        }

        public void DeleteData<TEntity>(TEntity data) where TEntity : EntityData
        {
            Remove(data);
        }

        public void Complete()
        {
            SaveChanges();
        }

        private string GetLogin() => _sessionAccessor.User?.Login ?? EntityData.DefaultUser;
        private DateTime GetDate() => DateTime.UtcNow;
    }
}

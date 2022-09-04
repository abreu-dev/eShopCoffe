using eShopCoffe.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eShopCoffe.Core.Data
{
    public interface IBaseContext : IUnitOfWork
    {
        bool IsAvailable();

        DbSet<TEntity> GetDbSet<TEntity>() where TEntity : EntityData;
        EntityEntry<TEntity> GetDbEntry<TEntity>(TEntity data) where TEntity : EntityData;
        IQueryable<TEntity> Query<TEntity>() where TEntity : EntityData;

        void AddData<TEntity>(TEntity data) where TEntity : EntityData;
        void UpdateData<TEntity>(TEntity data) where TEntity : EntityData;
        void UpdateState<TEntity>(TEntity data) where TEntity : EntityData;
        void DeleteData<TEntity>(TEntity data) where TEntity : EntityData;
    }
}

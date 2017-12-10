using Abp.Domain.Entities;

namespace ABPCMS.Caching.CachingSync
{
    public interface ICacheSyncService
    {
        void Add<TEntity>(TEntity entity) where TEntity : class, IEntity<int>;
        void Remove<TEntity>(int id) where TEntity : class, IEntity<int>;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity<int>;
    }
}
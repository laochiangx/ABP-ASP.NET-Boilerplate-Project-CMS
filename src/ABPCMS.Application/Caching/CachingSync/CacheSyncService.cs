using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Entities;

namespace ABPCMS.Caching.CachingSync
{
    public class CacheSyncService : ICacheSyncService, ISingletonDependency
    {
        public ICacheService CacheService { get; set; }

        public void Add<TEntity>(TEntity entity) where TEntity : class, IEntity<int>
        {
            CacheService.Set(entity.Id, entity);
        }

        public void Remove<TEntity>(int id) where TEntity : class, IEntity<int>
        {
            CacheService.Remove<int, TEntity>(id);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class, IEntity<int>
        {
            CacheService.Set(entity.Id, entity);
        }
    }
}
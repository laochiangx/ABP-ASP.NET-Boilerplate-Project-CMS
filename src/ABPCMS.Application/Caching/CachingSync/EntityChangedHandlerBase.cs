using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Castle.Core.Logging;
using Newtonsoft.Json;

namespace ABPCMS.Caching.CachingSync
{
    public abstract class EntityChangedHandlerBase<TEntity>:
        ISingletonDependency,
        IEventHandler<EntityCreatedEventData<TEntity>>,
        IEventHandler<EntityDeletedEventData<TEntity>>,
        IEventHandler<EntityUpdatedEventData<TEntity>>
        where TEntity : class, IEntity<int>
    {
        public ICacheSyncService CacheSyncService { get; set; }

        public virtual void HandleEvent(EntityCreatedEventData<TEntity> eventData)
        {
            CacheSyncService.Add(eventData.Entity);
        }

        public virtual void HandleEvent(EntityDeletedEventData<TEntity> eventData)
        {
            CacheSyncService.Remove<TEntity>(eventData.Entity.Id);
        }

        public virtual void HandleEvent(EntityUpdatedEventData<TEntity> eventData)
        {
            CacheSyncService.Update(eventData.Entity);
        }
    }
}
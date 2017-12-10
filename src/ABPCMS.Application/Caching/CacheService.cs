using System;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Abp.UI;

namespace ABPCMS.Caching
{
    public class CacheService : ICacheService,ISingletonDependency
    {
        public ICacheManager CacheManager { get; set; }

        public TValue GetCachedEntity<TKey, TValue>(TKey key) where TValue : class,IEntity<TKey>
        {
            var cache = CacheManager.GetCache<TKey, TValue>(typeof(TValue).Name);
            var item = cache.Get(key, () =>
            {
                var repository = IocManager.Instance.Resolve<IRepository<TValue, TKey>>();
                var entity = repository.FirstOrDefault(key);
                if (entity == null)
                {
                    throw new UserFriendlyException(string.Format("读取的信息不存在,Key:{0}",key));
                }
                return entity;
            });

            return item;
        }

        public TValue GetCachedEntity<TValue>(int key) where TValue : class, IEntity<int>
        {
            return GetCachedEntity<int, TValue>(key);
        }

        public void Set<TKey, TValue>(TKey key, TValue value, TimeSpan? slidingExpireTime = null)
        {
            var cache = CacheManager.GetCache<TKey, TValue>(typeof(TValue).Name);
            cache.Set(key, value, slidingExpireTime);
        }

        public void Remove<TKey,TValue>(TKey key)
        {
            var cache = CacheManager.GetCache<TKey, TValue>(typeof (TValue).Name);
            cache.Remove(key);
        }
    }
}
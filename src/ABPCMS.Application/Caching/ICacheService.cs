using System;
using Abp.Domain.Entities;

namespace ABPCMS.Caching
{
    public interface ICacheService
    {
        TValue GetCachedEntity<TKey, TValue>(TKey key) where TValue : class, IEntity<TKey>;
        TValue GetCachedEntity<TValue>(int key) where TValue : class, IEntity<int>;
        void Set<TKey, TValue>(TKey key, TValue value, TimeSpan? slidingExpireTime = null);
        void Remove<TKey,TValue>(TKey key);
    }
}
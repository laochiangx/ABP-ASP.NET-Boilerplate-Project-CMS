using System;
using Abp;
using Abp.RedisCache.Configuration;
using Abp.RedisCache.RedisImpl;
using Abp.Runtime.Caching;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ABPCMS.Caching
{
    public class RedisCache : CacheBase
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;
        private readonly AbpRedisCacheConfig _config;

        public IDatabase Database
        {
            get
            {
                return _connectionMultiplexer.GetDatabase();
            }
        }

        public RedisCache(string name, IAbpRedisConnectionProvider redisConnectionProvider, AbpRedisCacheConfig config)
            : base(name)
        {
            _config = config;
            var connectionString = redisConnectionProvider.GetConnectionString(_config.ConnectionStringKey);
            _connectionMultiplexer = redisConnectionProvider.GetConnection(connectionString);
        }

        public override object GetOrDefault(string key)
        {
            var obj = Database.StringGet(GetLocalizedKey(key));
            if (obj.HasValue)
            {
                var item = JsonConvert.DeserializeObject < RedisCacheItem>(obj);
                return JsonConvert.DeserializeObject(item.Item, item.Type);                
            }


            return null;
        }

        public override void Set(string key, object value, TimeSpan? slidingExpireTime = null)
        {
            if (value == null)
            {
                throw new AbpException("Can not insert null values to the cache!");
            }

            var cacheItem = new RedisCacheItem { Type = value.GetType(), Item = JsonConvert.SerializeObject(value) };

            Database.StringSet(
                GetLocalizedKey(key),
                JsonConvert.SerializeObject(cacheItem),
                slidingExpireTime
                );
        }

        public override void Remove(string key)
        {
            Database.KeyDelete(GetLocalizedKey(key));
        }

        public override void Clear()
        {
            Database.KeyDeleteWithPrefix(GetLocalizedKey("*"));
        }

        private string GetLocalizedKey(string key)
        {
            return "n:" + Name + ",c:" + key;
        }
    }
}
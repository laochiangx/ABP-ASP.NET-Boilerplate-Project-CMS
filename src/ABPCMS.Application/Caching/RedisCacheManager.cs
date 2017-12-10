using Abp.Dependency;
using Abp.Runtime.Caching;
using Abp.Runtime.Caching.Configuration;

namespace ABPCMS.Caching
{
    public class RedisCacheManager : CacheManagerBase
    {
        public RedisCacheManager(IIocManager iocManager, ICachingConfiguration configuration)
            : base(iocManager, configuration)
        {
            IocManager.RegisterIfNot<RedisCache>(DependencyLifeStyle.Transient);
        }
        protected override ICache CreateCacheImplementation(string name)
        {
            return IocManager.Resolve<RedisCache>(new { name });
        }
    }
}
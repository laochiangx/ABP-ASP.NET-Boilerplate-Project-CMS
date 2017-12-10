using System;

namespace ABPCMS.Caching
{
    public class RedisCacheItem
    {
        public Type Type { get; set; }
        public string Item { get; set; }
    }
}
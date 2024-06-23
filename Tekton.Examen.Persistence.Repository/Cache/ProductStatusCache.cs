using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekton.Examen.Application.Interface.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace Tekton.Examen.Persistence.Cache
{
    public class ProductStatusCache : IProductStatusCache
    {
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(5);
        private const string CacheKey = "ProductStatusDictionary";

        public ProductStatusCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Dictionary<int, string> GetProductStatusDictionary()
        {
            if (!_cache.TryGetValue(CacheKey, out Dictionary<int, string> statusDictionary))
            {
                statusDictionary = new Dictionary<int, string>
            {
                { 0, "Inactive" },
                { 1, "Active" }
            };

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = _cacheDuration
                };

                _cache.Set(CacheKey, statusDictionary, cacheEntryOptions);
            }

            return statusDictionary;
        }
    }
}

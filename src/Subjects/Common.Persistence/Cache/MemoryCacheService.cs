using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Goodtocode.Common.Persistence.Cache;

public class MemoryCacheService : ICacheService
{
    private readonly IMemoryCache _cache;
    private readonly CacheConfiguration _config;
    private readonly MemoryCacheEntryOptions _options;
    public MemoryCacheService(IMemoryCache memoryCache, IOptions<CacheConfiguration> cacheConfig)
    {
        _cache = memoryCache;
        _config = cacheConfig.Value;
        if (_config != null)
        {
            _options = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_config.AbsoluteExpirationInHours),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromMinutes(_config.SlidingExpirationInMinutes)
            };
        }
    }
    public bool TryGet<T>(string cacheKey, out T value)
    {
        _cache.TryGetValue(cacheKey, out value);
        if (value == null) return false;
        else return true;
    }
    public T Set<T>(string cacheKey, T value)
    {
        return _cache.Set(cacheKey, value, _options);
    }
    public void Remove(string cacheKey)
    {
        _cache.Remove(cacheKey);
    }
}
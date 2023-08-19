using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Goodtocode.Common.Persistence.Cache;

public class RedisCacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly CacheConfiguration _config;
    private readonly DistributedCacheEntryOptions _options;

    public RedisCacheService(IDistributedCache cache, IOptions<CacheConfiguration> cacheConfig)
    {
        _cache = cache;
        _config = cacheConfig.Value;
        if (_config != null)
        {
            _options = new DistributedCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddHours(_config.AbsoluteExpirationInHours),
                SlidingExpiration = TimeSpan.FromMinutes(_config.SlidingExpirationInMinutes)
            };
        }
    }

    public bool TryGet<T>(string cacheKey, out T value)
    {
        var serialized = _cache.GetString(cacheKey);
        value = JsonSerializer.Deserialize<T>(serialized);
        if (value == null) return false;
        else return true;
    }
    public T Set<T>(string cacheKey, T value)
    {
        _cache.SetString(cacheKey, JsonSerializer.Serialize(value), _options);
        return value;
    }
    public void Remove(string cacheKey)
    {
        _cache.Remove(cacheKey);
    }
}

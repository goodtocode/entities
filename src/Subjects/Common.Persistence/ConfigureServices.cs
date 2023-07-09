using Goodtocode.Common.Persistence.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Goodtocode.Common.Persistence;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<CacheConfiguration>(options => { configuration.GetSection("CacheConfiguration"); });
        //For In-Memory Caching
        services.AddMemoryCache();
        services.AddTransient<MemoryCacheService>();
        services.AddTransient<RedisCacheService>();
        services.AddTransient<Func<CacheTypes, ICacheService>>(serviceProvider => key =>
        {
            return key switch
            {
                CacheTypes.Memory => serviceProvider.GetService<MemoryCacheService>(),
                CacheTypes.Redis => serviceProvider.GetService<RedisCacheService>(),
                _ => serviceProvider.GetService<MemoryCacheService>()
            };
        });

        return services;
    }
}

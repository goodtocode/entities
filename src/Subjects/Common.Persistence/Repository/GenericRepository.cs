using Goodtocode.Common.Persistence.Cache;
using Microsoft.EntityFrameworkCore;

namespace Goodtocode.Common.Persistence.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly static CacheTypes CacheTypes = CacheTypes.Memory;
    private readonly string cacheKey = $"{typeof(T)}";
    private readonly DbContext _dbContext;
    private readonly Func<CacheTypes, ICacheService> _cacheService;
    public GenericRepository(DbContext dbContext, Func<CacheTypes, ICacheService> cacheService)
    {
        _dbContext = dbContext;
        _cacheService = cacheService;
    }
    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        if (!_cacheService(CacheTypes).TryGet(cacheKey, out IReadOnlyList<T> cachedList))
        {
            cachedList = await _dbContext.Set<T>().ToListAsync();
            _cacheService(CacheTypes).Set(cacheKey, cachedList);
        }
        return cachedList;
    }
    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        await RefreshCache();
        return entity;
    }
    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        await RefreshCache();
    }
    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        await RefreshCache();
    }
    public async Task RefreshCache()
    {
        _cacheService(CacheTypes).Remove(cacheKey);
        var cachedList = await _dbContext.Set<T>().ToListAsync();
        _cacheService(CacheTypes).Set(cacheKey, cachedList);
    }
}

using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Services.Interfaces;

namespace Services;

public class CacheService : ICacheService
{
    private readonly IDistributedCache _distributedCache;
    private readonly TimeSpan _cacheLifeTime = TimeSpan.FromMinutes(1);

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public async Task<string?> GetAsync(string key)
    {
        var valueBytes = await _distributedCache.GetAsync(key);
        if (valueBytes == null) return null;
        return Encoding.UTF8.GetString(valueBytes);
    }
    
    public async Task RemoveAsync(string key) => await _distributedCache.RemoveAsync(key);

    public async Task SetAsync(string key, string value)
    {
        var valueBytes = Encoding.UTF8.GetBytes(value);
        await _distributedCache.SetAsync(key, valueBytes, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = _cacheLifeTime });
    }
}
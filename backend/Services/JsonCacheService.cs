using System.Text.Json;
using Services.Interfaces;

namespace Services;

public class JsonCacheService : IJsonCacheService
{
    private readonly ICacheService _cacheService;

    public JsonCacheService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }
    
    public async Task<T?> GetAsync<T>(string key) 
        where T : class, new()
    {
        string? valueJson = await _cacheService.GetAsync(key);
        if (valueJson == null) return null;
        T? value = JsonSerializer.Deserialize<T>(valueJson);
        return value;
    }

    public async Task RemoveAsync(string key) => await _cacheService.RemoveAsync(key);

    public async Task SetAsync<T>(string key, T value)
        where T : class, new()
    {
        string valueJson = JsonSerializer.Serialize(value);
        await _cacheService.SetAsync(key, valueJson);
    }
}
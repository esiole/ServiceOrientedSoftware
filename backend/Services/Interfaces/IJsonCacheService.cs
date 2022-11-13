namespace Services.Interfaces;

public interface IJsonCacheService
{
    Task<T?> GetAsync<T>(string key) where T : class, new();
    Task RemoveAsync(string key);
    Task SetAsync<T>(string key, T value) where T : class, new();
}
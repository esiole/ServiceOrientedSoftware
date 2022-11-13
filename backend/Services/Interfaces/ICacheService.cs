namespace Services.Interfaces;

public interface ICacheService
{
    Task<string?> GetAsync(string key);
    Task RemoveAsync(string key);
    Task SetAsync(string key, string value);
}
namespace DBModel.Interfaces;

public interface IDbRepository<T>
{
    Task<T[]> GetAsync();
    Task AddAsync(T entity);
    Task RemoveAsync(int id);
}
using DBModel.Models;

namespace Services.Interfaces;

public interface IOrdersService
{
    Task<Order[]> GetAsync();
    Task AddAsync(Order order);
    Task RemoveAsync(int id);
}
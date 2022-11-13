using DBModel.Models;

namespace Services.Interfaces;

public interface IVendorsService
{
    Task<Vendor[]> GetAsync();
    Task AddAsync(Vendor vendor);
    Task RemoveAsync(int id);
}
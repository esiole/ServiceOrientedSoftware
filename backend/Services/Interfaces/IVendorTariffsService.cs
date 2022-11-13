using DBModel.Models;

namespace Services.Interfaces;

public interface IVendorTariffsService
{
    Task<VendorTariff[]> GetAsync();
    Task AddAsync(VendorTariff tariff);
    Task RemoveAsync(int id);
}
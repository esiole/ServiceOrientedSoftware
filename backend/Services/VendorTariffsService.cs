using DBModel.Interfaces;
using DBModel.Models;
using Services.Interfaces;

namespace Services;

public class VendorTariffsService : IVendorTariffsService
{
    private readonly IVendorTariffsRepository _vendorTariffsRepository;

    public VendorTariffsService(IVendorTariffsRepository vendorTariffsRepository)
    {
        _vendorTariffsRepository = vendorTariffsRepository;
    }

    public async Task<VendorTariff[]> GetAsync() => await _vendorTariffsRepository.GetAsync();
    public async Task AddAsync(VendorTariff tariff) => await _vendorTariffsRepository.AddAsync(tariff);
    public async Task RemoveAsync(int id) => await _vendorTariffsRepository.RemoveAsync(id);
}
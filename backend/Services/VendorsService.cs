using DBModel.Interfaces;
using DBModel.Models;
using Services.Interfaces;

namespace Services;

public class VendorsService : IVendorsService
{
    private readonly IVendorsRepository _vendorsRepository;

    public VendorsService(IVendorsRepository vendorsRepository)
    {
        _vendorsRepository = vendorsRepository;
    }

    public async Task<Vendor[]> GetAsync() => await _vendorsRepository.GetAsync();
    public async Task AddAsync(Vendor vendor) => await _vendorsRepository.AddAsync(vendor);
    public async Task RemoveAsync(int id) => await _vendorsRepository.RemoveAsync(id);
}
namespace DBModel.Repositories;

public class VendorTariffsRepository : IVendorTariffsRepository
{
    private readonly AppDbContext _context;

    public VendorTariffsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<VendorTariff[]> GetAsync()
    {
        return await _context.VendorTariffs
            .Include(t => t.Vendor)
            .ToArrayAsync();
    }

    public async Task AddAsync(VendorTariff entity)
    {
        await _context.VendorTariffs.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var tariff = await _context.VendorTariffs.FirstOrDefaultAsync(t => t.Id == id);
        if (tariff != null)
        {
            _context.VendorTariffs.Remove(tariff);
            await _context.SaveChangesAsync();
        }
    }
}
namespace DBModel.Repositories;

public class VendorsRepository : IVendorsRepository
{
    private readonly AppDbContext _context;
    
    public VendorsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Vendor[]> GetAsync()
    {
        return await _context.Vendors.ToArrayAsync();
    }

    public async Task AddAsync(Vendor entity)
    {
        await _context.Vendors.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == id);
        if (vendor != null)
        {
            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();
        }
    }
}
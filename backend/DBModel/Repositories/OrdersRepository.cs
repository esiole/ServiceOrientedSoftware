namespace DBModel.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly AppDbContext _context;
    
    public OrdersRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Order[]> GetAsync()
    {
        return await _context.Orders
            .Include(o => o.From)
            .Include(o => o.To)
            .Include(o => o.CargoItems)
            .Include(o => o.VendorTariff)
            .ToArrayAsync();
    }

    public async Task AddAsync(Order entity)
    {
        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }
}
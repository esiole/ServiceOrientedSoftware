namespace DBModel.Repositories;

public class StatsRepository : IStatsRepository
{
    private readonly AppDbContext _context;
    
    public StatsRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Stats[]> GetAsync()
    {
        return await _context.Stats.ToArrayAsync();
    }

    public async Task AddAsync(Stats entity)
    {
        await _context.Stats.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var stats = await _context.Stats.FirstOrDefaultAsync(s => s.Id == id);
        if (stats != null)
        {
            _context.Stats.Add(stats);
            await _context.SaveChangesAsync();
        }
    }
}
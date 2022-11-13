using DBModel;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly IDistributedCache _distributedCache;
    private readonly AppDbContext _context;
    private readonly ICacheService _cacheService;
    
    public TestController(IDistributedCache distributedCache, AppDbContext context, ICacheService cacheService)
    {
        _distributedCache = distributedCache;
        _context = context;
        _cacheService = cacheService;
    }
    
    // [HttpGet]
    // public IActionResult Get()
    // {
    //     var array = new byte[] {1, 2, 3, 4, 5}; 
    //     _distributedCache.Set("key", array); 
    //     var value = _distributedCache.Get("key");
    //     Console.WriteLine(value?.Length);
    //     return Ok(value);
    // }
    
    [HttpGet]
    public async Task<IActionResult> Get1()
    {
        await _cacheService.SetAsync("abcd", "from cache");
        string? value = await _cacheService.GetAsync("abcd");
        Console.WriteLine(value);
        return Ok(value);
    }
}
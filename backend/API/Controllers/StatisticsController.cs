using Services.Dto;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("current")]
    public async Task<IActionResult> Get()
    {
        var statistic = await _statisticsService.GetAsync();
        return Ok(new Statistic(statistic));
    }
    
    [HttpGet("history")]
    public async Task<IActionResult> GetHistory()
    {
        var statistic = await _statisticsService.GetHistoryAsync();
        return Ok(statistic);
    }
}
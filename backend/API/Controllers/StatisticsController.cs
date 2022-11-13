﻿namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var statistic = await _statisticsService.GetAsync();
        return Ok(statistic);
    }
}
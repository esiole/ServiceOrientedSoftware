using Services.Dto;

namespace Services.Interfaces;

public interface IStatisticsService
{
    Task<Statistic> GetAsync();
    Task Clear();
}
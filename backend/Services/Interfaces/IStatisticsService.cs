using DBModel.Models;
using Services.Dto;

namespace Services.Interfaces;

public interface IStatisticsService
{
    Task<Stats> GetAsync();
    Task<Stats[]> GetHistoryAsync();
    Task Clear();
}
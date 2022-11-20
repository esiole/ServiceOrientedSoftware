using DBModel.Interfaces;
using DBModel.Models;
using Services.Dto;
using Services.Interfaces;

namespace Services;

public class StatisticsService : IStatisticsService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IStatsRepository _statsRepository;
    private readonly IJsonCacheService _jsonCacheService;

    public static readonly string StatisticCacheKey = "statistic";

    public StatisticsService(IOrdersRepository ordersRepository, IStatsRepository statsRepository, IJsonCacheService jsonCacheService)
    {
        _ordersRepository = ordersRepository;
        _statsRepository = statsRepository;
        _jsonCacheService = jsonCacheService;
    }

    public async Task<Stats> GetAsync()
    {
        var statistic = await _jsonCacheService.GetAsync<Stats>(StatisticCacheKey);

        if (statistic == null)
        {
            await Task.Delay(7000);
            var orders = await _ordersRepository.GetAsync();

            if (orders.Length == 0) return null;

            var cargoItems = orders.SelectMany(o => o.CargoItems).ToArray();
            int cargoItemsQty = cargoItems.Sum(i => i.Qty);

            statistic = new Stats
            {
                Qty = orders.Length,
                AverageWeight = cargoItems.Sum(i => i.Weight * i.Qty) / (double) cargoItemsQty,
                AverageVolume = cargoItems.Sum(i => i.Volume * i.Qty) / (double) cargoItemsQty,
            };
            
            await _jsonCacheService.SetAsync(StatisticCacheKey, statistic);
        }
        
        return statistic;
    }

    public async Task<Stats[]> GetHistoryAsync() => await _statsRepository.GetAsync();

    public async Task Clear()
    {
        var statistic = await _jsonCacheService.GetAsync<Stats>(StatisticCacheKey);
        if (statistic != null)
        {
            statistic.Created = DateTime.Now;
            await _statsRepository.AddAsync(statistic);
            await _jsonCacheService.RemoveAsync(StatisticCacheKey);
        }
    }
}
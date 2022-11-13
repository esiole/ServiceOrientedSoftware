using DBModel.Interfaces;
using Services.Dto;
using Services.Interfaces;

namespace Services;

public class StatisticsService : IStatisticsService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IJsonCacheService _jsonCacheService;

    public static readonly string StatisticCacheKey = "statistic";

    public StatisticsService(IOrdersRepository ordersRepository, IJsonCacheService jsonCacheService)
    {
        _ordersRepository = ordersRepository;
        _jsonCacheService = jsonCacheService;
    }

    public async Task<Statistic> GetAsync()
    {
        var statistic = await _jsonCacheService.GetAsync<Statistic>(StatisticCacheKey);

        if (statistic == null)
        {
            await Task.Delay(7000);
            var orders = await _ordersRepository.GetAsync();

            if (orders.Length == 0) return null;

            var cargoItems = orders.SelectMany(o => o.CargoItems).ToArray();
            int cargoItemsQty = cargoItems.Sum(i => i.Qty);

            statistic = new Statistic
            {
                Qty = orders.Length,
                AverageWeight = cargoItems.Sum(i => i.Weight * i.Qty) / (double) cargoItemsQty,
                AverageVolume = cargoItems.Sum(i => i.Volume * i.Qty) / (double) cargoItemsQty,
            };
            
            await _jsonCacheService.SetAsync(StatisticCacheKey, statistic);
        }
        
        return statistic;
    }

    public async Task Clear() => await _jsonCacheService.RemoveAsync(StatisticCacheKey);
}
using DBModel.Interfaces;
using DBModel.Models;
using Services.Interfaces;

namespace Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    private readonly IStatisticsService _statisticsService;

    public OrdersService(IOrdersRepository ordersRepository, IStatisticsService statisticsService)
    {
        _ordersRepository = ordersRepository;
        _statisticsService = statisticsService;
    }

    public async Task<Order[]> GetAsync() => await _ordersRepository.GetAsync();
    
    public async Task AddAsync(Order order)
    {
        await _statisticsService.Clear();
        await _ordersRepository.AddAsync(order);
    }

    public async Task RemoveAsync(int id)
    {
        await _statisticsService.Clear();
        await _ordersRepository.RemoveAsync(id);
    }
}
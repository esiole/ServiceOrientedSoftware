namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var orders = await _ordersService.GetAsync();
        var result = orders.Select(o => new OrderViewModel(o));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] OrderReqModel model)
    {
        await _ordersService.AddAsync(model.ToOrder());
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int id)
    {
        await _ordersService.RemoveAsync(id);
        return Ok();
    }
}
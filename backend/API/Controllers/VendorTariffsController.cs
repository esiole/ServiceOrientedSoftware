namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorTariffsController : ControllerBase
{
    private readonly IVendorTariffsService _vendorTariffsService;

    public VendorTariffsController(IVendorTariffsService vendorTariffsService)
    {
        _vendorTariffsService = vendorTariffsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tariffs = await _vendorTariffsService.GetAsync();
        var result = tariffs.Select(t => new VendorTariffViewModel(t));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VendorTariffReqModel model)
    {
        await _vendorTariffsService.AddAsync(model.ToVendorTariff());
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int id)
    {
        await _vendorTariffsService.RemoveAsync(id);
        return Ok();
    }
}
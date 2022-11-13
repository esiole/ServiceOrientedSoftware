namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendorsController : ControllerBase
{
    private readonly IVendorsService _vendorsService;

    public VendorsController(IVendorsService vendorsService)
    {
        _vendorsService = vendorsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var vendors = await _vendorsService.GetAsync();
        var result = vendors.Select(v => new VendorViewModel(v));
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VendorReqModel model)
    {
        await _vendorsService.AddAsync(model.ToVendor());
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Remove([FromQuery] int id)
    {
        await _vendorsService.RemoveAsync(id);
        return Ok();
    }
}
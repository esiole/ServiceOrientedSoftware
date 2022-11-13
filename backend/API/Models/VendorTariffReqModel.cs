namespace API.Models;

public class VendorTariffReqModel
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required]
    [MaxLength(50)]
    public string VendorTariffId { get; set; } = null!;
    
    [Required]
    public int VendorId { get; set; }
        
    public VendorTariff ToVendorTariff() => new()
    {
        Name = Name,
        VendorId = VendorId,
        VendorTariffId = VendorTariffId
    };
}
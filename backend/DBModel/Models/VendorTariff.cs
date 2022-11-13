namespace DBModel.Models;

[Table("vendorTariffs")]
public class VendorTariff
{
    public int Id { get; set; }

    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)] 
    public string VendorTariffId { get; set; } = string.Empty;
    
    [Required]
    public int VendorId { get; set; }
    public Vendor? Vendor { get; set; }
    
    public List<Order>? Orders { get; set; }
}
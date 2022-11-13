namespace DBModel.Models;

[Table("vendors")]
public class Vendor
{
    public int Id { get; set; }

    [MaxLength(50)] 
    public string Name { get; set; } = string.Empty;
    
    public List<VendorTariff>? VendorTariffs { get; set; }
}
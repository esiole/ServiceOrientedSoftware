namespace DBModel.Models;

[Table("orders")]
public class Order
{
    public int Id { get; set; }
    
    [Required]
    public int FromId { get; set; }
    public FromContact? From { get; set; }
    
    [Required]
    public int ToId { get; set; }
    public ToContact? To { get; set; }
    
    [Required]
    public int VendorTariffId { get; set; }
    public VendorTariff? VendorTariff { get; set; }
    
    [MaxLength(1000)] 
    public string? Description { get; set; }
    
    public List<CargoItem>? CargoItems { get; set; }
}
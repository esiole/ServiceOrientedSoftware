namespace API.Models;

public class OrderReqModel
{
    [Required]
    public ContactModel From { get; set; }
    
    [Required]
    public ContactModel To { get; set; }
    
    [Required]
    public CargoItemModel[] CargoItems { get; set; }
    
    [Required]
    public int VendorTariffId { get; set; }
    
    [MaxLength(1000)] 
    public string? Description { get; set; }
        
    public Order ToOrder() => new()
    {
        From = From.ToFromContact(),
        To = To.ToToContact(),
        CargoItems = CargoItems.Select(i => i.ToCargoItem()).ToList(),
        Description = Description,
        VendorTariffId = VendorTariffId
    };
}
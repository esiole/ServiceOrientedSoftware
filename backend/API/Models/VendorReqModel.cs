namespace API.Models;

public class VendorReqModel
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;

    public Vendor ToVendor() => new()
    {
        Name = Name
    };
}
namespace API.Models;

public class VendorViewModel
{
    public int Id { get; }
    public string Name { get; }

    public VendorViewModel(Vendor vendor)
    {
        Id = vendor.Id;
        Name = vendor.Name;
    }
}
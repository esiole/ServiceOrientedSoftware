namespace API.Models;

public class VendorTariffViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int VendorId { get; set; }
    public string VendorName { get; set; }

    public VendorTariffViewModel(VendorTariff tariff)
    {
        Id = tariff.Id;
        Name = tariff.Name;
        VendorId = tariff.VendorId;
        VendorName = tariff.Vendor.Name;
    }
}
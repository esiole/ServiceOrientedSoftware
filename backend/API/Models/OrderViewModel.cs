namespace API.Models;

public class OrderViewModel
{
    public int Id { get; set; }
    public ContactModel From { get; set; }
    public ContactModel To { get; set; }
    public List<CargoItemModel> CargoItems { get; set; }
    public int VendorTariffId { get; set; }
    public string? Description { get; set; }

    public OrderViewModel(Order order)
    {
        Id = order.Id;
        From = new ContactModel(order.From);
        To = new ContactModel(order.To);
        CargoItems = order.CargoItems.ConvertAll(i => new CargoItemModel(i));
        VendorTariffId = order.VendorTariffId;
        Description = order.Description;
    }
}
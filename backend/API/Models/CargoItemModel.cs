namespace API.Models;

public class CargoItemModel
{
    [Required]
    public double Length { get; set; }
    
    [Required]
    public double Width { get; set; }
    
    [Required]
    public double Height { get; set; }
    
    [Required]
    public double Weight { get; set; }
    
    [Required]
    public int Qty { get; set; }
    
    public CargoItemModel() { }

    public CargoItemModel(CargoItem item)
    {
        Length = item.Length;
        Width = item.Width;
        Height = item.Height;
        Weight = item.Weight;
        Qty = item.Qty;
    }

    public CargoItem ToCargoItem() => new()
    {
        Length = Length,
        Width = Width,
        Height = Height,
        Weight = Weight,
        Qty = Qty
    };
}
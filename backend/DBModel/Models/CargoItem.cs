namespace DBModel.Models;

[Table("cargoItems")]
public class CargoItem
{
    public int Id { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    
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

    public double Volume => Length * Width * Height;
}
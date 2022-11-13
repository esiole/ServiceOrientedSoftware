namespace DBModel.Models;

[Table("contacts")]
public class Contact
{
    public int Id { get; set; }

    [MaxLength(100)] 
    public string CityName { get; set; } = string.Empty;
    
    [MaxLength(150)] 
    public string Address { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string ContactPersonName { get; set; }
    
    [Required]
    public int OrderId { get; set; }
    public Order? Order { get; set; }
}

[Table("fromContact")]
public class FromContact : Contact { }

[Table("toContact")]
public class ToContact : Contact { }
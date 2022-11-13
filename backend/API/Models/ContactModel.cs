namespace API.Models;

public class ContactModel
{
    [Required]
    [MaxLength(100)] 
    public string CityName { get; set; }
    
    [Required]
    [MaxLength(150)] 
    public string Address { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string ContactPersonName { get; set; }
    
    public ContactModel() { }

    public ContactModel(Contact contact)
    {
        CityName = contact.CityName;
        Address = contact.Address;
        ContactPersonName = contact.ContactPersonName;
    }

    public Contact ToContact() => new()
    {
        CityName = CityName,
        Address = Address,
        ContactPersonName = ContactPersonName
    };
    
    public FromContact ToFromContact() => new()
    {
        CityName = CityName,
        Address = Address,
        ContactPersonName = ContactPersonName
    };
    
    public ToContact ToToContact() => new()
    {
        CityName = CityName,
        Address = Address,
        ContactPersonName = ContactPersonName
    };
}
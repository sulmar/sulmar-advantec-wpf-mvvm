namespace Domain.Models;

public class User : BaseEntity
{
    private string? _Name;
    public string? Name 
    { 
        get => _Name;
        set
        {
            _Name = value;
            OnPropertyChanged();
        }
    }

    private string _Email;
    public string? Email
    {
        get => _Email;
        set
        {
            _Email = value;
            OnPropertyChanged();
        } 
    }
    public Address? HomeAddress { get; set; }
    public Address? ShippingAddress { get; set; }

}

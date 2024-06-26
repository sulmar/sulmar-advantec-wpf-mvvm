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
    public Address HomeAddress { get; set; } = new Address();
    public Address ShippingAddress { get; set; } = new Address();
    public decimal Salary { get; set; }

}

public abstract class SearchCriteria : Base
{ 
}

public class UserSearchCriteria : SearchCriteria
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? City { get; set; }
    public decimal? FromSalary { get; set; }
    public decimal? ToSalary { get; set; }
}
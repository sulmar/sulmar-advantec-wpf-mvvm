using System.Collections;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace Domain.Models;

public class User : BaseEntity, INotifyDataErrorInfo
{
    private readonly Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

    private string? _Name;
    public string? Name
    {
        get => _Name;
        set
        {
            _Name = value;
            ValidateName();
            OnPropertyChanged();
        }
    }

    private void ValidateName()
    {
        ClearErrors(nameof(Name));  

        if (string.IsNullOrEmpty(Name))
            AddError(nameof(Name), "Name cannot by empty");

        if (Name?.Length <= 5)
            AddError(nameof(Name), "Name must be at least 5 characters");

    }

    protected void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }

    private void AddError(string propertyName, string error)
    {
        if (!errors.ContainsKey(propertyName))
            errors[propertyName] = new List<string>();
        
        if (!errors[propertyName].Contains(error))
        {
            errors[propertyName].Add(error);
            OnErrorsChanged(propertyName);
        }

    }

    private void ClearErrors(string propertyName)
    {
        if (errors.ContainsKey(propertyName))
        {
            errors.Remove(propertyName);
            OnErrorsChanged(propertyName);
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

    #region INotifyDataErrorInfo

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    public bool HasErrors => errors.Any();
    public IEnumerable GetErrors(string? propertyName)
    {
        return errors.ContainsKey(propertyName) ? errors[propertyName] : null;
    }

    #endregion
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
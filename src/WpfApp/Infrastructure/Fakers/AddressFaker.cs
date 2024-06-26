using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

public class AddressFaker : Faker<Address>
{
    public AddressFaker()
    {
        RuleFor(p => p.Street, f => f.Address.StreetAddress());
        RuleFor(p => p.City, f => f.Address.City());
        RuleFor(p=>p.ZipCode, f=>f.Address.ZipCode());
        RuleFor(p=>p.Country, f => f.Address.Country());
    }
}

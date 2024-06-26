using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

public class UserFaker : Faker<User>
{
    public UserFaker(Faker<Address> addressFaker)
    {
        StrictMode(true);
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Person.FullName);
        RuleFor(p=>p.Email, f=>f.Person.Email);
        RuleFor(p=> p.HomeAddress, addressFaker.Generate());
        RuleFor(p=>p.ShippingAddress, addressFaker.Generate());
    }
}

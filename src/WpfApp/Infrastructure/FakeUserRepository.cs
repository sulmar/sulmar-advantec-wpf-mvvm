using Domain.Abstractions;
using Domain.Models;
using System.Net.Http.Headers;

namespace Infrastructure;

public class FakeUserRepository : FakeEntityRepository<User>, IUserRepository
{
    public FakeUserRepository(List<User> entities) : base(entities)
    {
    }
}

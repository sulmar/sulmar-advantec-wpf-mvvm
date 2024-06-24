using Domain.Abstractions;
using Domain.Models;
namespace Infrastructure;

public class AppDbContext
{

}

public class DbUserRepository : IUserRepository
{
    public DbUserRepository(AppDbContext context)
    {
        
    }
    public List<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(User user)
    {
        throw new NotImplementedException();
    }

    public void Update(User user)
    {
        throw new NotImplementedException();
    }

}

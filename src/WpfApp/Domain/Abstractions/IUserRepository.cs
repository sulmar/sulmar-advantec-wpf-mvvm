using Domain.Models;

namespace Domain.Abstractions;

public interface IUserRepository : IEntityRepository<User>
{
    List<User> GetBy(UserSearchCriteria searchCriteria);
}

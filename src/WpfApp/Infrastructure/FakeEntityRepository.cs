using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeEntityRepository<T> : IEntityRepository<T>
    where T : BaseEntity
{
    protected IDictionary<int, T> _entities = new Dictionary<int, T>();

    public FakeEntityRepository(List<T> entities)
    {
        _entities = entities.ToDictionary(p => p.Id);
    }

    public void Add(T entity)
    {
        _entities.Add(entity.Id, entity);
    }

    public List<T> GetAll()
    {
        return _entities.Values.ToList();
    }
}

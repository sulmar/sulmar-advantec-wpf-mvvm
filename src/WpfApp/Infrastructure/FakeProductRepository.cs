using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
{
    public FakeProductRepository(List<Product> entities) : base(entities)
    {
    }

    public List<Product> GetByColor(string color)
    {
        return _entities
            .Select(p => p.Value)
            .Where(p => p.Color == color)
            .ToList();
    }
}

using Domain.Models;

namespace Domain.Abstractions;

public interface IProductRepository : IEntityRepository<Product>
{
    List<Product> GetByColor(string color);
}
namespace Domain.Abstractions;

// Interfejs generyczny (ugolniony) - szablon
public interface IEntityRepository<T>
{
    List<T> GetAll();
    void Add(T entity);
}

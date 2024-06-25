using Domain.Abstractions;

namespace WpfApp.ViewModels;

class EntitiesViewModel<T> : BaseViewModel
{
    public List<T> Entities { get; set; }

    public EntitiesViewModel(IEntityRepository<T> repository)
    {
        Entities = repository.GetAll();
    }
}

using Domain.Abstractions;
using Domain.Models;

namespace WpfApp.ViewModels;


abstract class BaseViewModel
{

}

class EntitiesViewModel<T> : BaseViewModel
{
    public List<T> Entities { get; set; }

    public EntitiesViewModel(IEntityRepository<T> repository)
    {
        Entities = repository.GetAll();
    }
}

class UsersViewModel : BaseViewModel
{
    public List<User> Users { get; set; }

	public UsersViewModel(IUserRepository userRepository)
	{
		Users = userRepository.GetAll();
	}
}

class ProductViewModel : EntitiesViewModel<Product>
{
    public ProductViewModel(IProductRepository repository) : base(repository)
    {
    }
}

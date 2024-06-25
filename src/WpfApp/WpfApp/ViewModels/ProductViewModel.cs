using Domain.Abstractions;
using Domain.Models;

namespace WpfApp.ViewModels;

class ProductViewModel : EntitiesViewModel<Product>
{
    public ProductViewModel(IProductRepository repository) : base(repository)
    {
    }
}

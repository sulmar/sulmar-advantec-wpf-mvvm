using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Services;
using WpfApp.Views;

namespace WpfApp.ViewModels;

class ShellViewModel : BaseViewModel
{
    private readonly INavigationService navigationService;

    public ICommand NavigateToUsersCommand { get; }
    public ICommand NavigateToProductsCommand { get; }  

    public ShellViewModel(INavigationService navigationService)
    {
        NavigateToUsersCommand = new RelayCommand(NavigateToUsers);
        NavigateToProductsCommand = new RelayCommand(NavigateToProducts);
        this.navigationService = navigationService;
    }

    private void NavigateToUsers(object obj)
    {
        navigationService.NavigateTo("Users");
    }

    private void NavigateToProducts(object obj)
    {
        navigationService.NavigateTo("Products");
    }

}

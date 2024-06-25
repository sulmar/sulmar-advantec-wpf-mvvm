using Domain.Abstractions;
using Domain.Models;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels;

class UsersViewModel : BaseViewModel
{
    public ObservableCollection<User> Users { get; set; }

    public ICommand AddUserCommand { get; set; }

    public UsersViewModel(IUserRepository userRepository)
    {
        Users = new ObservableCollection<User>(userRepository.GetAll());

        AddUserCommand = new RelayCommand(AddUser);
    }

    private void AddUser(object obj)
    {
        AddUserView dialog = new AddUserView();
        var result = dialog.ShowDialog();

        if (result == true)
        {
            User newUser = ((AddUserViewModel)dialog.DataContext).User;
            Users.Add(newUser);
        }
    }
}

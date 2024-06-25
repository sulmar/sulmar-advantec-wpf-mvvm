using Domain.Abstractions;
using Domain.Models;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows.Input;
using WpfApp.Commands;

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
        Users.Add(new User { Id = 99, Name = "a", Email = "b" });
    }
}

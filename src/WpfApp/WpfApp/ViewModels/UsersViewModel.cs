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

    private User _SelectedUser;
    public User SelectedUser
    {
        get => _SelectedUser;
        set 
        {
            _SelectedUser = value;
            RemoveUserCommand.RaiseCanExecuteChanged();
            EditUserCommand.RaiseCanExecuteChanged();
        }
    }

    public ICommand AddUserCommand { get; }
    public RelayCommand EditUserCommand { get; }
    public RelayCommand RemoveUserCommand { get;  }

    public UsersViewModel(IUserRepository userRepository)
    {
        Users = new ObservableCollection<User>(userRepository.GetAll());

        AddUserCommand = new RelayCommand(AddUser);
        EditUserCommand = new RelayCommand(EditUser, CanEditUser);
        RemoveUserCommand = new RelayCommand(RemoveUser,CanRemoveUser);
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

    private void EditUser(object obj)
    {
        AddUserView dialog = new AddUserView();
        dialog.User = SelectedUser;
        var result = dialog.ShowDialog();
    }

    private bool CanEditUser(object obj) => IsSelectedUser;

    public bool IsSelectedUser => SelectedUser != null;
    private bool CanRemoveUser(object obj) => IsSelectedUser;
    private void RemoveUser(object obj) => Users.Remove(SelectedUser);
}

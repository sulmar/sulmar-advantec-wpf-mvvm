using Domain.Abstractions;
using Domain.Models;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels;


partial class UsersViewModel : BaseViewModel
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

    private IUserRepository _userRepository;

    public UsersViewModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        Users = new ObservableCollection<User>(_userRepository.GetAll());

        AddUserCommand = new RelayCommand(AddUser);
        EditUserCommand = new RelayCommand(EditUser, CanEditUser);
        RemoveUserCommand = new RelayCommand(RemoveUser,CanRemoveUser);
        UpdateUserCommand = new RelayCommand(UpdateUser);
    }

    private void AddUser(object obj)
    {
        AddUserView dialog = new AddUserView();
        var result = dialog.ShowDialog();

        if (result == true)
        {
            User newUser = ((AddUserViewModel)dialog.DataContext).User;

            try
            {
                _userRepository.Add(newUser);
                Users.Add(newUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpil blad podczas zapisu", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    private void EditUser(object obj)
    {
        var dialog = new EditUserView();
        dialog.User = SelectedUser;
        var result = dialog.ShowDialog();

        if (result == true)
        {
            // TODO: Zapisz w db
        }
    }

    private bool CanEditUser(object obj) => IsSelectedUser;

    public bool IsSelectedUser => SelectedUser != null;
    private bool CanRemoveUser(object obj) => IsSelectedUser;
    private void RemoveUser(object obj) => Users.Remove(SelectedUser);

    private void UpdateUser(object obj)
    {
        SelectedUser.Email = SelectedUser.Email.ToUpper();
    }


}

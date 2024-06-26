using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels;

class EditUserViewModel : BaseViewModel
{
    private User user;
    public User User
    {
        get => user;
        set
        {
            user = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; set; }

    public event Action<User> UserSaved;
    public event Action UserCancelled;

    public EditUserViewModel()
    {
        SaveCommand = new RelayCommand(Save);
    }

    private void Save(object obj)
    {
        UserSaved?.Invoke(User);
    }

    private void Cancel(object obj)
    {
        UserCancelled?.Invoke();
    }
}

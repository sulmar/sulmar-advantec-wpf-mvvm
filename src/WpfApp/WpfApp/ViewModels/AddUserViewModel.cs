using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels;

class AddUserViewModel : BaseViewModel
{
    public User User { get; set; } = new();

    public ICommand SaveCommand { get; set; }

    public event Action<User> UserSaved;
    public event Action UserCancelled;

    public AddUserViewModel()
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

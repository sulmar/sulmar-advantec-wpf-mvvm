using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp.Commands;
using WpfApp.Views;

namespace WpfApp.ViewModels;

partial class UsersViewModel
{
    public ICommand AddUserCommand { get; }
    public RelayCommand EditUserCommand { get; }
    public RelayCommand RemoveUserCommand { get; }
    public RelayCommand UpdateUserCommand { get; set; }

}

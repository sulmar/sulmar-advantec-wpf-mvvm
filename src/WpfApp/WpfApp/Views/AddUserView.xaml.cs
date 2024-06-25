using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp.ViewModels;

namespace WpfApp.Views
{
    /// <summary>
    /// Interaction logic for AddUserView.xaml
    /// </summary>
    public partial class AddUserView : Window
    {
        public AddUserView()
        {
            InitializeComponent();

            var viewModel = App.Current.Services.GetRequiredService<AddUserViewModel>();
            this.DataContext = viewModel;

           // viewModel.UserSaved += ViewModel_UserSaved;
            viewModel.UserSaved += user => { DialogResult = true; Close(); };
        }

        //private void ViewModel_UserSaved(Domain.Models.User user)
        //{
        //    DialogResult = true; 
        //    Close();
        //}
    }
}

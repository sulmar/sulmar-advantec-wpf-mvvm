using Domain.Models;
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
    /// Interaction logic for EditUserView.xaml
    /// </summary>
    public partial class EditUserView : Window
    {
        public User User { get; set; }

        EditUserViewModel viewModel = App.Current.Services.GetRequiredService<EditUserViewModel>();

        public EditUserView()
        {
            InitializeComponent();
          
            this.DataContext = viewModel;

            this.Loaded += EditUserView_Loaded;

            viewModel.UserSaved += user => { DialogResult = true; Close(); };
        }

        private void EditUserView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel.User = User;
        }
    }
}

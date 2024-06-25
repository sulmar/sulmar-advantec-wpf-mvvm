using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp.ViewModels;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        // Install-Package Microsoft.Extensions.DependencyInjection

        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();

        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<UsersViewModel>();
            services.AddSingleton<IUserRepository, FakeUserRepository>();

            services.AddTransient<AddUserViewModel>();

            services.AddSingleton<ProductViewModel>();
            services.AddSingleton<IProductRepository, FakeProductRepository>();


            services.AddSingleton<List<Product>>(sp =>
            {
                return new List<Product>
                {

                };
            });


            services.AddSingleton<List<User>>(sp =>
            {
                return new List<User>
                {
                    new User { Id = 1, Name = "John Smith", Email = "john@domain.com" },
                    new User { Id = 2, Name = "Bob Smith", Email = "bob@domain.com" },
                    new User { Id = 3, Name = "Kate Smith", Email = "kate@domain.com" },
                };
            });


            return services.BuildServiceProvider();
        }
    }

}

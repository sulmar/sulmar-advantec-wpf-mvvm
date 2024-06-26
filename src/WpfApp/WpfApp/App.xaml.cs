using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
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
            services.AddTransient<EditUserViewModel>();

            services.AddSingleton<ProductViewModel>();
            services.AddSingleton<IProductRepository, FakeProductRepository>();


            services.AddSingleton<List<Product>>(sp =>
            {
                return new List<Product>
                {

                };
            });


            services.AddSingleton<Faker<User>, UserFaker>();
            services.AddSingleton<Faker<Address>, AddressFaker>();

            services.AddSingleton<List<User>>(sp =>
            {
                var faker = sp.GetRequiredService<Faker<User>>();

                var users = faker.Generate(20);
                return users;
            });


            return services.BuildServiceProvider();
        }
    }

}

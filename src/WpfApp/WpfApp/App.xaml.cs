using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure;
using Infrastructure.Fakers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp.Services;
using WpfApp.ViewModels;
using WpfApp.Views;

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
        
        public static IConfiguration Configuration { get; set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Services = ConfigureServices();

            var context = Services.GetRequiredService<AppDbContext>();

            context.Database.EnsureCreated();

            var navigationService = Services.GetRequiredService<INavigationService>();

            navigationService.RegisterRoute("Users", typeof(UsersPageView));
            navigationService.RegisterRoute("Products", typeof(ProductsPageView));
        }

        private static IServiceProvider ConfigureServices()
        {
            var connectionString = Configuration.GetConnectionString("AppDb");

            var services = new ServiceCollection();

            services.AddSingleton<UsersViewModel>();
            services.AddSingleton<IUserRepository, DbUserRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddSingleton<ShellViewModel>();

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


            services.AddSingleton<INavigationService, FrameNavigationService>();

            services.AddSingleton<UsersPageView>();
            services.AddSingleton<ProductsPageView>();

            return services.BuildServiceProvider();
        }
    }

}

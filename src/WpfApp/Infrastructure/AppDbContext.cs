using Domain.Models;
using Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

// Install-Package Microsoft.EntityFrameworkCore.SqlServer

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new ProductConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}

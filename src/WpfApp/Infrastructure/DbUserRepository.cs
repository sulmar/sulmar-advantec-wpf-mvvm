using Domain.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure;

// Microsoft.EntityFrameworkCore.SqlServer

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}

public class DbUserRepository : IUserRepository
{
    private readonly AppDbContext context;

    public DbUserRepository(AppDbContext context)
    {
        this.context = context;
    }
    public List<User> GetAll()
    {
        return context.Users.ToList();
    }

    public void Add(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public void Update(User user)
    {
        // context.Users.Update(user);
        context.SaveChanges();
    }

    public List<User> GetBy(UserSearchCriteria searchCriteria)
    {
        var query = context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(searchCriteria.Name))
            query = query.Where(p => p.Name.Contains(searchCriteria.Name));

        if (!string.IsNullOrEmpty(searchCriteria.Email))
            query = query.Where(p => p.Email.Contains(searchCriteria.Email));

        if (searchCriteria.FromSalary.HasValue)
            query = query.Where(p => p.Salary >= searchCriteria.FromSalary.Value);

        if (searchCriteria.ToSalary.HasValue)
            query = query.Where(p => p.Salary <= searchCriteria.ToSalary.Value);

        // https://www.albahari.com/nutshell/predicatebuilder.aspx
        return query.ToList();

    }
}

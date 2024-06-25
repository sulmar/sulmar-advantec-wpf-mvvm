using System.Diagnostics;

namespace Domain.Models;

public interface IProductCommand
{
    void Execute();
}

public class PrintCommand : IProductCommand
{
    private Product product;

    public PrintCommand(Product product)
    {
        this.product = product;
    }

    public void Execute()
    {
        Console.WriteLine(product.Name);
    }
}

public class ChangePriceCommand : IProductCommand
{
    private Product product;
    private decimal delta;

    public ChangePriceCommand(Product product, decimal delta)
    {
        this.product = product;
        this.delta = delta;
    }

    public void Execute()
    {
        product.Price += delta;
    }
}

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }

  
}

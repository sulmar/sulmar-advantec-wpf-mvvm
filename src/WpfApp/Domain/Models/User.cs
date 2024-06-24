namespace Domain.Models;

public class User : BaseEntity
{

    public required string Name { get; set; }
    public string? Email { get; set; }
}

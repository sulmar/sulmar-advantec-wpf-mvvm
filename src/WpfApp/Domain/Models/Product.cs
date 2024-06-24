﻿namespace Domain.Models;

public class Product : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Color { get; set; }
    public decimal Price { get; set; }
}

﻿namespace Domain.Models;

public class User : BaseEntity
{
    public string? Name { get; set; }
    public string? Email { get; set; }
}

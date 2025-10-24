﻿namespace SuppliersPortal.Models;

public class SupplierDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateSupplierRequest
{
    public string Name { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

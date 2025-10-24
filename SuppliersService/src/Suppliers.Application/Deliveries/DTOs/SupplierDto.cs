namespace Suppliers.Application.Suppliers.DTOs;

public sealed class SupplierDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Cnpj { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}

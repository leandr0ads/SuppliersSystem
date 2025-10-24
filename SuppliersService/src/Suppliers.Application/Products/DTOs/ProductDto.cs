namespace Suppliers.Application.Products.DTOs;

public sealed class ProductDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public decimal UnitPrice { get; init; }
    public DateTime CreatedAt { get; init; }
}

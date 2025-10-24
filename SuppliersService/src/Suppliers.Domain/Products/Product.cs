using Suppliers.Domain.Abstractions;

namespace Suppliers.Domain.Products;

public sealed class Product : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal UnitPrice { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Guid> _deliveryIds = new();
    public IReadOnlyCollection<Guid> DeliveryIds => _deliveryIds.AsReadOnly();

    private Product() : base() { }

    private Product(string name, string description, decimal unitPrice) : base()
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name is required.", nameof(name));

        Name = name.Trim();
        Description = description?.Trim() ?? string.Empty;
        UnitPrice = unitPrice <= 0 ? throw new ArgumentException("Unit price must be positive.") : unitPrice;
        CreatedAt = DateTime.UtcNow;
    }

    public static Product Create(string name, string description, decimal price)
        => new(name, description, price);
}

using Suppliers.Domain.Abstractions;

namespace Suppliers.Domain.Suppliers;

public sealed class Supplier : Entity
{
    public string Name { get; private set; }
    public string Cnpj { get; private set; } // ou CPF, dependendo do contexto
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private readonly List<Guid> _deliveryIds = new();
    public IReadOnlyCollection<Guid> DeliveryIds => _deliveryIds.AsReadOnly();

    private Supplier() : base() { }

    private Supplier(string name, string cnpj, string email) : base()
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Supplier name is required.", nameof(name));

        Name = name.Trim();
        Cnpj = cnpj.Trim();
        Email = email.Trim().ToLowerInvariant();
        CreatedAt = DateTime.UtcNow;
    }

    public static Supplier Create(string name, string cnpj, string email)
        => new(name, cnpj, email);
}

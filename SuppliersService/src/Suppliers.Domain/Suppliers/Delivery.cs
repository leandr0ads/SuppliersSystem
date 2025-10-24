using Suppliers.Domain.Abstractions;

namespace Suppliers.Domain.Deliveries;

public sealed class Delivery : Entity
{
    public Guid SupplierId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public DateTime DeliveryDate { get; private set; }

    private Delivery() : base() { }

    private Delivery(Guid supplierId, Guid productId, int quantity, DateTime deliveryDate) : base()
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.");

        SupplierId = supplierId;
        ProductId = productId;
        Quantity = quantity;
        DeliveryDate = deliveryDate;
    }

    public static Delivery Create(Guid supplierId, Guid productId, int quantity, DateTime deliveryDate)
        => new(supplierId, productId, quantity, deliveryDate);
}

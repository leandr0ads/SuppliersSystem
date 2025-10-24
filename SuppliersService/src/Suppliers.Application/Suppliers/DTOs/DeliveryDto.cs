namespace Suppliers.Application.Deliveries.DTOs;

public sealed class DeliveryDto
{
    public Guid Id { get; init; }
    public Guid SupplierId { get; init; }
    public Guid ProductId { get; init; }
    public int Quantity { get; init; }
    public DateTime DeliveryDate { get; init; }
}

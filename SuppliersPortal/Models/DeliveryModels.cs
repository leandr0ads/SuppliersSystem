namespace SuppliersPortal.Models;

public class DeliveryDto
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime DeliveryDate { get; set; }
}

public class RegisterDeliveryRequest
{
    public Guid SupplierId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime DeliveryDate { get; set; }
}

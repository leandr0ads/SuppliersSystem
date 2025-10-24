using Suppliers.Domain.Deliveries;

namespace Suppliers.Application.Abstractions;

public interface IDeliveryRepository
{
    Task AddAsync(Delivery delivery, CancellationToken ct = default);
    Task<IEnumerable<Delivery>> GetAllAsync(CancellationToken ct = default);
}

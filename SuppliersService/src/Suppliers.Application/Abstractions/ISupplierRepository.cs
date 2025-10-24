using Suppliers.Domain.Suppliers;

namespace Suppliers.Application.Abstractions;

public interface ISupplierRepository
{
    Task AddAsync(Supplier supplier, CancellationToken ct = default);
    Task<Supplier?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken ct = default);
}

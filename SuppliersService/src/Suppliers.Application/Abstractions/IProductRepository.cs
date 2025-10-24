using Suppliers.Domain.Products;

namespace Suppliers.Application.Abstractions;

public interface IProductRepository
{
    Task AddAsync(Product product, CancellationToken ct = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default);
}

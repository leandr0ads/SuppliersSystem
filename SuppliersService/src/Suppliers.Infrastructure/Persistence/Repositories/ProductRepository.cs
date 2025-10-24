using Microsoft.EntityFrameworkCore;
using Suppliers.Application.Abstractions;
using Suppliers.Domain.Products;

namespace Suppliers.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SuppliersDbContext _context;

    public ProductRepository(SuppliersDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product product, CancellationToken ct = default)
    {
        await _context.Products.AddAsync(product, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
        => await _context.Products.AsNoTracking().ToListAsync(ct);

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _context.Products.FindAsync(new object?[] { id }, ct);
}

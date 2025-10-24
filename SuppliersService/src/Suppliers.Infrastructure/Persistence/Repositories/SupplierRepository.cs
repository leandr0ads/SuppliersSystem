using Microsoft.EntityFrameworkCore;
using Suppliers.Application.Abstractions;
using Suppliers.Domain.Suppliers;

namespace Suppliers.Infrastructure.Persistence.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly SuppliersDbContext _context;

    public SupplierRepository(SuppliersDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Supplier supplier, CancellationToken ct = default)
    {
        await _context.Suppliers.AddAsync(supplier, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync(CancellationToken ct = default)
        => await _context.Suppliers.AsNoTracking().ToListAsync(ct);

    public async Task<Supplier?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _context.Suppliers.FindAsync(new object?[] { id }, ct);
}

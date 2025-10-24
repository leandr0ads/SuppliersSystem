using Microsoft.EntityFrameworkCore;
using Suppliers.Application.Abstractions;
using Suppliers.Domain.Deliveries;

namespace Suppliers.Infrastructure.Persistence.Repositories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly SuppliersDbContext _context;

    public DeliveryRepository(SuppliersDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Delivery delivery, CancellationToken ct = default)
    {
        await _context.Deliveries.AddAsync(delivery, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Delivery>> GetAllAsync(CancellationToken ct = default)
        => await _context.Deliveries.AsNoTracking().ToListAsync(ct);
}

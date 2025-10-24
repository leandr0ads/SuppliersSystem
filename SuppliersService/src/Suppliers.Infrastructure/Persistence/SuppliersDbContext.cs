using Microsoft.EntityFrameworkCore;
using Suppliers.Domain.Deliveries;
using Suppliers.Domain.Products;
using Suppliers.Domain.Suppliers;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Suppliers.Infrastructure.Persistence;

public class SuppliersDbContext : DbContext
{
    public SuppliersDbContext(DbContextOptions<SuppliersDbContext> options) : base(options) { }

    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Delivery> Deliveries => Set<Delivery>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SuppliersDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

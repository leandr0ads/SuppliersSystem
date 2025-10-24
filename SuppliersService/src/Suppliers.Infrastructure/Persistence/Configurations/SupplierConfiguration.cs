using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suppliers.Domain.Suppliers;

namespace Suppliers.Infrastructure.Persistence.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Suppliers");
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(150);
        builder.Property(s => s.Cnpj).IsRequired().HasMaxLength(20);
        builder.Property(s => s.Email).IsRequired().HasMaxLength(150);
        builder.Property(s => s.CreatedAt).IsRequired();
    }
}

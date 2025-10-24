using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Suppliers.Domain.Deliveries;

namespace Suppliers.Infrastructure.Persistence.Configurations;

public class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
{
    public void Configure(EntityTypeBuilder<Delivery> builder)
    {
        builder.ToTable("Suppliers");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Quantity).IsRequired();
        builder.Property(d => d.DeliveryDate).IsRequired();

        builder.HasOne<Suppliers.Domain.Suppliers.Supplier>()
               .WithMany()
               .HasForeignKey(d => d.SupplierId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Suppliers.Domain.Products.Product>()
               .WithMany()
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Auth.Domain.Users;

namespace Auth.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.OwnsOne(u => u.Email, e =>
        {
            e.Property(x => x.Value)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(200);
        });

        builder.OwnsOne(u => u.PasswordHash, p =>
        {
            p.Property(x => x.Value)
                .HasColumnName("PasswordHash")
                .IsRequired()
                .HasMaxLength(200);
        });

        builder.Property(u => u.Role)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(u => u.CreatedAt);
        builder.Property(u => u.UpdatedAt);
    }
}

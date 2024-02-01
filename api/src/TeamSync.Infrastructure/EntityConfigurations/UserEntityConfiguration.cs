using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;
public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.UserId).IsRequired();
        builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Password).IsRequired().IsEncrypted();
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.IsClockedIn).HasDefaultValue(false);
        builder.Property(u => u.Metadata).HasColumnType("jsonb");

        // Relationship

        builder.HasOne(u => u.Organisation)
        .WithMany(u => u.Users)
        .HasForeignKey(u => u.OrganisationId);

        builder.HasMany(u => u.TimeLogs)
        .WithOne()
        .HasForeignKey(u => u.UserId);
    }
}
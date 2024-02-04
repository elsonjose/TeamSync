using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;

/// <summary>
/// Defines the entity type configuration for <seealso cref="TimeLog"/>
/// </summary>
public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Defines the configure method.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.UserId)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired()
            .ValueGeneratedOnAdd(); ;
        builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.HashSalt).IsRequired();
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.IsClockedIn).HasDefaultValue(false);
        builder.Property(u => u.Metadata).HasColumnType("jsonb");

        // Relationship

        builder.HasOne(u => u.Organisation)
        .WithMany(u => u.Users)
        .HasForeignKey(u => u.OrganisationId);

        builder.HasMany(u => u.TimeLogs)
        .WithOne(t => t.User)
        .HasForeignKey(u => u.UserId)
        .HasPrincipalKey(u => u.UserId);
    }
}
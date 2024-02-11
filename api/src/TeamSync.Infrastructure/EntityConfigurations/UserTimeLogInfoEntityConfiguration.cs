using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;

/// <summary>
/// Defines the entity type configuration for <seealso cref="UserTimeLogInfo"/>
/// </summary>
public class UserTimeLogInfoEntityConfiguration : IEntityTypeConfiguration<UserTimeLogInfo>
{
    /// <summary>
    /// Defines the configure method.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<UserTimeLogInfo> builder)
    {
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.UserId)
            .HasColumnType("uuid")
            .IsRequired();
        builder.Property(u => u.IsClockedIn).IsRequired().HasDefaultValue(false);
        builder.Property(u => u.LastClockedId).IsRequired();
        builder.Property(u => u.LastClockedTime).IsRequired();
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;

/// <summary>
/// Defines the entity type configuration for <seealso cref="TimeLog"/>
/// </summary>
public class TimeLogEntityConfiguration : IEntityTypeConfiguration<TimeLog>
{
    /// <summary>
    /// Defines the configure method.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<TimeLog> builder)
    {
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        // Relationship
        builder.HasOne(t => t.User)
            .WithMany(u => u.TimeLogs)
            .HasForeignKey(t => t.UserId)
            .HasPrincipalKey(t => t.UserId);
    }
}
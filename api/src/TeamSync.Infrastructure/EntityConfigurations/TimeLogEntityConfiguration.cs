using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;

public class TimeLogEntityConfiguration : IEntityTypeConfiguration<TimeLog>
{
    public void Configure(EntityTypeBuilder<TimeLog> builder)
    {
        builder.Property(t => t.Id).ValueGeneratedOnAdd();
        builder.Property(t => t.ClockedInTime < t.ClockedOutTime);

        // Relationship
        builder.HasOne(t => t.User)
            .WithMany()
            .HasPrincipalKey(t => t.UserId);
    }
}
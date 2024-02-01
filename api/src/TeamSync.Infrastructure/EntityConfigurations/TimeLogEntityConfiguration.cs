using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;

public class TimeLogEntityConfiguration : IEntityTypeConfiguration<TimeLog>
{
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;
public class OrganisationEntityConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.OrganisationId)
            .HasColumnType("uuid")
            .HasDefaultValueSql("gen_random_uuid()")
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(u => u.Name).IsRequired().HasMaxLength(256);
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.Property(u => u.HashSalt).IsRequired();
        builder.Property(u => u.Metadata).HasColumnType("jsonb");

        // Relationship
        
        builder.HasMany(o => o.Users)
        .WithOne()
        .HasForeignKey(o => o.OrganisationId);
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.EntityConfigurations;
public class OrganisationEntityConfiguration : IEntityTypeConfiguration<Organisation>
{
    public void Configure(EntityTypeBuilder<Organisation> builder)
    {
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.OrganisationId).IsRequired();
        builder.Property(u => u.Name).IsRequired().HasMaxLength(256);
        builder.Property(u => u.ShortCode).IsRequired().HasMaxLength(8);
        builder.Property(u => u.IsActive).HasDefaultValue(true);
        builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
        builder.Property(u => u.Password).IsEncrypted();
        builder.Property(u => u.Metadata).HasColumnType("jsonb");

        // Relationship
        
        builder.HasMany(u => u.Users)
        .WithOne()
        .HasForeignKey(u => u.OrganisationId);
    }
}
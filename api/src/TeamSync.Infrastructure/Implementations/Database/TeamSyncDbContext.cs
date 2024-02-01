using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;
using Microsoft.Extensions.Configuration;
using TeamSync.Application.Common;
using TeamSync.Application.Interfaces;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.Implementation.Database;

public class TeamSyncDbContext : DbContext, ITeamSyncDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }

    private readonly IConfiguration _configuration;
    private readonly IEncryptionProvider _provider;

    public TeamSyncDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        (IConfigurationSection encryptionKeySection, IConfigurationSection encryptionIVSection) = GetEncryptionDetails(configuration);

        var encryptionKey = Encoding.ASCII.GetBytes(encryptionKeySection.ToString());
        var encryptionIV = Encoding.ASCII.GetBytes(encryptionIVSection.ToString());

        _provider = new AesProvider(encryptionKey, encryptionIV);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Use encryption
        modelBuilder.UseEncryption(_provider);

        // Apply uniqueness
        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.UserId).IsUnique();
            e.HasIndex(u => u.OrganisationId);
        });

        modelBuilder.Entity<Organisation>(e =>
        {
            e.HasIndex(o => o.OrganisationId).IsUnique();
        });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeamSyncDbContext).Assembly);
    }

    private (IConfigurationSection encryptionKeySection, IConfigurationSection encryptionIVSection) GetEncryptionDetails(IConfiguration configuration)
    {
        return (configuration.GetRequiredSection(TeamSyncConstants.EncryptionKey), configuration.GetRequiredSection(TeamSyncConstants.EncryptionIV));
    }
}
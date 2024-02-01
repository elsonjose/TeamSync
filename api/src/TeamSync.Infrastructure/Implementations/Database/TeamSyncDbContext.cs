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

    // private readonly IConfiguration _configuration;
    private readonly IEncryptionProvider _provider;

    public TeamSyncDbContext(DbContextOptions<TeamSyncDbContext> dbContextOptions) : base(dbContextOptions)
    {
        // var builder = new ConfigurationBuilder()
        //             .SetBasePath(Directory.GetCurrentDirectory())
        //             .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
        //             .AddJsonFile("appSettings.Development.json", optional: true, reloadOnChange: true);
        // _configuration = builder.Build();

        // (IConfigurationSection encryptionKeySection, IConfigurationSection encryptionIVSection) = GetEncryptionDetails(_configuration);

        var encryptionKey = Encoding.ASCII.GetBytes("ZZx0qsJ5IGThaA1InDs8/6BmaUb9hfN5dSYQxdlFaKgVVwG04HNuwG2s/Ty9odBS");
        var encryptionIV = Encoding.ASCII.GetBytes("+Hij5RyepsASjSUmxLpVdAro3L3NG4XDOTVPH8sr1fg7ulr/9SMy/e0HnMKy7gnF");

        _provider = new AesProvider(encryptionKey, encryptionIV);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
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
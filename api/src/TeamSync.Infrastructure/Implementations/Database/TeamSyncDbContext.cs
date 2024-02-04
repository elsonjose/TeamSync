using Microsoft.EntityFrameworkCore;
using TeamSync.Application.Interfaces;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.Implementation.Database;

/// <summary>
/// Defines the TeamSync Database context.
/// </summary>
public class TeamSyncDbContext : DbContext, ITeamSyncDbContext
{
    /// <summary>
    /// Specifies the users db set.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Specifies the organisation db set.
    /// </summary>
    public DbSet<Organisation> Organisations { get; set; }

    /// <summary>
    /// Specifies the time-log db set.
    /// </summary>
    public DbSet<TimeLog> TimeLogs { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="TeamSyncDbContext"/>
    /// </summary>
    /// <param name="dbContextOptions"></param>
    public TeamSyncDbContext(DbContextOptions<TeamSyncDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

    /// <summary>
    /// Overrires the model creating method for <see cref="TeamSyncDbContext"/>
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // For uuid generation
        modelBuilder.HasPostgresExtension("pgcrypto");

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

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
using Microsoft.EntityFrameworkCore;
using TeamSync.Application.Interfaces;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.Implementation.Database;

public class TeamSyncDbContext : DbContext, ITeamSyncDbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Organisation> Organisations { get; set; }

    public DbSet<TimeLog> TimeLogs { get; set; }


    public TeamSyncDbContext(DbContextOptions<TeamSyncDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }

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

    public void SaveChages()
    {
        base.SaveChanges();
    }
}
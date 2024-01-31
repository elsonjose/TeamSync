using Microsoft.EntityFrameworkCore;
using TeamSync.Application.Interfaces;
using TeamSync.Domain.Entities;

namespace TeamSync.Infrastructure.Implementation.Database;

public class TeamSyncDbContext : DbContext, ITeamSyncDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Organisation> Organisations { get; set; }
    public DbSet<TimeLog> TimeLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TeamSyncDbContext).Assembly);
    }
}
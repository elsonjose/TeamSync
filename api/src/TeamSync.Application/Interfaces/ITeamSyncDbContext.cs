using Microsoft.EntityFrameworkCore;
using TeamSync.Domain.Entities;

namespace TeamSync.Application.Interfaces;

/// <summary>
/// Defines the interface for TeamSync DB.
/// </summary>
public interface ITeamSyncDbContext
{
    /// <summary>
    /// Specifies the collection of users.
    /// </summary>
    DbSet<User> Users { get; set; }

    /// <summary>
    /// Specifies the collection of organisations.
    /// </summary>
    DbSet<Organisation> Organisations { get; set; }

    /// <summary>
    /// Specifies the collection of time logs.
    /// </summary>
    DbSet<TimeLog> TimeLogs { get; set; }

    /// <summary>
    /// Defines the method to save changes.
    /// </summary>
    /// <returns>The number of entities written to db.</returns>
    int SaveChanges();

    /// <summary>
    /// Defines the method to save changes asynchronously.
    /// </summary>
    /// <returns> A task awaiting number of entities written to db.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
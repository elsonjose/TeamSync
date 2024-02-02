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

    void SaveChages();
}
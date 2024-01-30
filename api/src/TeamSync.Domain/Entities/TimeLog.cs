namespace TeamSync.Domain.Entities;

/// <summary>
/// Defines the time-log entity,
/// </summary>
public class TimeLog
{
    /// <summary>
    /// Specifies the identifier for the time log.
    /// </summary>
    public long Id { get; set; }

    /// <summary>
    /// Specifies the clocked in time.
    /// </summary>
    public long ClockedInTime { get; set; }

    /// <summary>
    /// Specifies the clocked out time.
    /// </summary>
    public long ClockedOutTime { get; set; }

    /// <summary>
    /// Specifies the time at which the log was created.
    /// </summary>
    public long CreatedOn { get; set; }

    /// <summary>
    /// Specifies the time at which the log was created.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    /// Specifies the associated user.
    /// </summary>
    public User User { get; set; } = null!;
}

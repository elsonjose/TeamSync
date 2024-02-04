namespace TeamSync.Application.Interfaces;

/// <summary>
/// Defines the interface for date time provider.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Specifies the datetime in Utc now.
    /// </summary>
    DateTime UtcNow { get; }
}
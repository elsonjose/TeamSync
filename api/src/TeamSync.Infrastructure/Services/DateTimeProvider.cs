using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Services;

/// <summary>
/// Defines the implementation of date time provider
/// </summary>
public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;                  
}
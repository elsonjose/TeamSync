using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;                  
}
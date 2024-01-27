using TeamSync.Application.Common.Interfaces;

namespace TeamSync.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;                  
}
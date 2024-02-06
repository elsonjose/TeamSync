using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Implementations;
public class RequestContext : IRequestContext
{
    /// <summary>
    /// Specifies the time zone offset in minuts.
    /// </summary>
    public int TimeZoneOffset { get; set; }

    /// <summary>
    /// Specifies the orginisation identifier.
    /// </summary>
    private Guid OrganisationId { get; set; }

    /// <summary>
    /// Specifies the user identifier.
    /// </summary>
    private Guid? UserId { get; set; }

    /// <summary>
    /// Specifies whether the user is organisation.
    /// </summary>
    private bool IsOrganisation { get; set; }


    public Guid GetOrganisationIdFromToken()
    {
        return OrganisationId;
    }

    public int GetTimeZoneOffsetFromHeader()
    {
        return TimeZoneOffset;
    }

    public Guid GetUserIdFromToken()
    {
        if (UserId.HasValue)
        {
            return UserId.Value;
        }
        throw new Exception("User id not found");
    }

    public void SetValues(int timeZoneOffset, Guid? userId, Guid orgId, bool isOrg)
    {
        TimeZoneOffset = timeZoneOffset;
        OrganisationId = orgId;
        UserId = userId;
        IsOrganisation = isOrg;
    }
}
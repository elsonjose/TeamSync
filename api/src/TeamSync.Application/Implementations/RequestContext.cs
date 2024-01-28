using TeamSync.Application.Interfaces;

namespace TeamSync.Application.Implementations;
public class RequestContext : IRequestContext
{
    /// <summary>
    /// Specifies the time zone offset in minuts.
    /// </summary>
    private int TimeZoneOffset { get; set; }

    /// <summary>
    /// Specifies the orginisation identifier.
    /// </summary>
    private int OrganisationId { get; set; }

    /// <summary>
    /// Specifies the user identifier.
    /// </summary>
    private int UserId { get; set; }

    /// <summary>
    /// Specifies whether the user is organisation.
    /// </summary>
    private bool IsOrganisation { get; set; }


    public int GetOrganisationIdFromToken()
    {
        return OrganisationId;
    }

    public int GetTimeZoneOffsetFromHeader()
    {
        return TimeZoneOffset;
    }

    public int GetUserIdFromToken()
    {
        return UserId;
    }

    public void SetValues(int timeZoneOffset, int userId, int orgId, bool isOrg)
    {
        TimeZoneOffset = timeZoneOffset;
        OrganisationId = orgId;
        UserId = userId;
        IsOrganisation = isOrg;
    }
}
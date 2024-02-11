using TeamSync.Application.Common.Exceptions;
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
    private string? OrganisationId { get; set; }

    /// <summary>
    /// Specifies the user identifier.
    /// </summary>
    private string? UserId { get; set; }

    /// <summary>
    /// Specifies whether the user is organisation.
    /// </summary>
    private string? IsOrganisation { get; set; }


    public Guid GetOrganisationIdFromToken()
    {
        if (string.IsNullOrEmpty(OrganisationId))
        {
            throw new TeamSyncException("Organisation id is null.");
        }
        return new Guid(OrganisationId);
    }

    public int GetTimeZoneOffsetFromHeader()
    {
        return TimeZoneOffset;
    }

    public Guid GetUserIdFromToken()
    {
        if (string.IsNullOrEmpty(UserId))
        {
            throw new TeamSyncException("User id is null.");
        }
        return new Guid(UserId);
    }

    public bool IsOrganisationAdmin()
    {
        if (string.IsNullOrEmpty(IsOrganisation))
        {
            throw new TeamSyncException("User id is null.");
        }
        return Convert.ToBoolean(IsOrganisation);
    }

    public void SetValues(int timeZoneOffset, string? userId, string? orgId, string? isOrg)
    {
        TimeZoneOffset = timeZoneOffset;
        OrganisationId = orgId;
        UserId = userId;
        IsOrganisation = isOrg;
    }
}
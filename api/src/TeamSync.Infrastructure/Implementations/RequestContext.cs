using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using TeamSync.Api;
using TeamSync.Application.Common.Exceptions;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure.Services.Authencation;
using static TeamSync.Application.Common.TeamSyncEnums;

namespace TeamSync.Infrastructure.Implementations;
public class RequestContext : IRequestContext
{
    /// <summary>
    /// Specifies the http context accessor instance.
    /// </summary>
    private readonly IHttpContextAccessor _httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of <seealso cref="RequestContext"/>
    /// </summary>
    /// <param name="httpContextAccessor"></param>
    public RequestContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetOrganisationIdFromToken()
    {
        var organisationId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        if (string.IsNullOrEmpty(organisationId))
        {
            throw new TeamSyncException(TeamSyncExceptionCodes.BadRequest, "Organisation id field is missing in authorization token");
        }
        return new Guid(organisationId);
    }

    public int GetTimeZoneOffsetFromHeader()
    {
        var timeZoneOffset = _httpContextAccessor.HttpContext?.Request.Headers[ApplicationConstants.TimeZoneOffsetHeader.ToLower()];
        if (string.IsNullOrEmpty(timeZoneOffset))
        {
            throw new TeamSyncException(TeamSyncExceptionCodes.BadRequest, "Timezone offset is missing in header.");
        }
        return Convert.ToInt32(timeZoneOffset);
    }

    public Guid GetUserIdFromToken()
    {
        var userId = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == TeamSyncClaimNames.UserId)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            throw new TeamSyncException(TeamSyncExceptionCodes.BadRequest, "User id field is missing in authorization token.");
        }
        return new Guid(userId);
    }

    public bool IsOrganisationAdmin()
    {
        var isOrganisation = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == TeamSyncClaimNames.IsOrganisation)?.Value;
        if (string.IsNullOrEmpty(isOrganisation))
        {
            throw new TeamSyncException(TeamSyncExceptionCodes.BadRequest, "Is organisation field is missing in authorization token.");
        }
        return Convert.ToBoolean(isOrganisation);
    }
}
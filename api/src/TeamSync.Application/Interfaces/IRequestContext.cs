namespace TeamSync.Application.Interfaces;

/// <summary>
/// Defines the interface for request context.
/// </summary>
public interface IRequestContext
{
    /// <summary>
    /// Gets the time time zone offset from header.
    /// </summary>
    /// <returns>The time zone offset in minutes.</returns>
    int GetTimeZoneOffsetFromHeader();

    /// <summary>
    /// Gets the user identifier from token.
    /// </summary>
    /// <returns>The user identifier.</returns>
    int GetUserIdFromToken();

    /// <summary>
    /// Gets the organisation identifier from the token.
    /// </summary>
    /// <returns>The organisation identifier.</returns>
    int GetOrganisationIdFromToken();

    /// <summary>
    /// Sets the values
    /// </summary>
    /// <param name="timeZoneOffset"></param>
    /// <param name="userId"></param>
    /// <param name="OrgId"></param>
    void SetValues(int timeZoneOffset, int userId, int orgId, bool isOrg);
}
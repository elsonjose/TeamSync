namespace TeamSync.Application.Interfaces;

/// <summary>
/// Defines the interface of JWT token generation.
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Generates the JWT token.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="organisationId"></param>
    /// <param name="isOrganisation"></param>
    /// <returns>The JWT token.</returns>
    public string GenerateToken(Guid? userId, Guid organisationId, bool isOrganisation);
}
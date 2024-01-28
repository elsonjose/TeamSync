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
    /// <param name="firstName"></param>
    /// <param name="lastname"></param>
    /// <param name="organisationId"></param>
    /// <returns>The JWT token.</returns>
    public string GenerateToken(int userId, string firstName, string lastname, int organisationId);
}
namespace TeamSync.Infrastructure.Services.Authencation;

/// <summary>
/// Defines the JWT settings model.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Specifies the secret.
    /// </summary>
    public string Secret { get; init; } = null!;

    /// <summary>
    /// Specifies the audience.
    /// </summary>
    public string Audience { get; init; } = null!;

    /// <summary>
    /// Specifies the issuer.
    /// </summary>
    public string Issuer { get; init; } = null!;

    /// <summary>
    /// Specifies the expiry in minutes.
    /// </summary>
    public int ExpiryInMinutes { get; init; }
}
namespace TeamSync.Contracts.Authencation;


/// <summary>
/// Defines the response for authentication
/// </summary>
public class AuthencationResponse
{
    /// <summary>
    /// Specifies the user identifier.
    /// </summary>
    /// <example>1</example>
    public int UserId { get; init; }

    /// <summary>
    /// Specifies the first name.
    /// </summary>
    /// <example>FirtName</example>
    public required string FirstName { get; init; }

    /// <summary>
    /// Specifies the last name.
    /// </summary>
    /// <example>LastName</example>
    public required string LastName { get; init; }

    /// <summary>
    /// Specifies the user email.
    /// </summary>
    /// <example>user@domain.com</example>
    public required string Email { get; init; }

    /// <summary>
    /// Specifies the token issued.
    /// </summary>
    /// <example>abcdefgh</example>
    public required string Token { get; init; }
}
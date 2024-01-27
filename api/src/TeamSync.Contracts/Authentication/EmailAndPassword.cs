namespace TeamSync.Contracts.Authencation;

/// <summary>
/// Defines the class containing email and password
/// </summary>
public class EmailAndPassword
{
    /// <summary>
    /// Specifies the email.
    /// </summary>
    /// <example>user@domain.com</example>
    public required string Email { get; init; }

    /// <summary>
    /// Specifies the password
    /// </summary>
    /// <example>Password</example>
    public required string Password { get; init; }
}
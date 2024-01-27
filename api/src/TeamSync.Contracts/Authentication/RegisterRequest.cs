namespace TeamSync.Contracts.Authencation;

/// <summary>
/// Defines the class for register request.
/// </summary>
public class RegisterRequest : EmailAndPassword
{
    /// <summary>
    /// Specifies the first name.
    /// </summary>
    /// <example>user@domain.com</example>
    public string FirstName { get; init; }

    /// <summary>
    /// Specifies the email.
    /// </summary>
    /// <example>user@domain.com</example>
    public string LastName { get; init; }
}
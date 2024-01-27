namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Specifies the authentication response from application layer.
/// </summary>
/// <param name="UserId"></param>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="Email"></param>
/// <param name="Token"></param>
public record AuthenticationResult(int UserId, string FirstName, string LastName, string Email, string Token);
namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Defines the authentication service.
/// </summary>
public class AuthenicationService : IAuthencticationService
{
    public AuthenticationResult Login(string Email, string Password)
    {
        return new AuthenticationResult(1, "FirstName", "LastName", "Email", "Token");
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {
        return new AuthenticationResult(1, "FirstName", "LastName", "Email", "Token");
    }
}
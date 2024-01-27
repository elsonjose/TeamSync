
namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Defines an interface for authentication service
/// </summary>
public interface IAuthencticationService
{
    /// <summary>
    /// Defines the login method.
    /// </summary>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <returns>Result of login process of type <see cref="AuthenticationResult"/></returns>
    public AuthenticationResult Login(string Email, string Password);

    /// <summary>
    /// Defines the register method.
    /// </summary>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="Email"></param>
    /// <param name="Password"></param>
    /// <returns>Result of register process of type <see cref="AuthenticationResult"/></returns>
    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password);
}
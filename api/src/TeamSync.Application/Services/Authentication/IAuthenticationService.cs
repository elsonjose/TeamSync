
namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Defines an interface for authentication service
/// </summary>
public interface IAuthencticationService
{
    /// <summary>
    /// Defines the login method.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns>Result of login process of type <see cref="AuthenticationResult"/></returns>
    public AuthenticationResult Login(string email, string password);

    /// <summary>
    /// Defines the register method.
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns>Result of register process of type <see cref="AuthenticationResult"/></returns>
    public AuthenticationResult Register(string firstName, string lastName, string email, string password);
}
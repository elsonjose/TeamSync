using TeamSync.Application.Common.Interfaces;

namespace TeamSync.Application.Services.Authenication;

/// <summary>
/// Defines the authentication service.
/// </summary>
public class AuthenicationService : IAuthencticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenicationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {

        var token = _jwtTokenGenerator.GenerateToken(1, "firstName", "lastName", 1);
        return new AuthenticationResult(1, "FirstName", "LastName", "Email", token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        var token = _jwtTokenGenerator.GenerateToken(1, firstName, lastName, 1);
        return new AuthenticationResult(1, firstName, lastName, email, token);
    }
}
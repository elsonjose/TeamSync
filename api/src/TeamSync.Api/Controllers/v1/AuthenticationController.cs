using Microsoft.AspNetCore.Mvc;
using TeamSync.Application.Services.Authenication;
using TeamSync.Contracts.Authencation;

namespace TeamSync.Api.v1.Controllers;

public class AuthenticationController : ApiController
{
    private readonly IAuthencticationService _authenticationService;

    public AuthenticationController(IAuthencticationService authService)
    {
        _authenticationService = authService;
    }

    [HttpPost("auth/login")]
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationService.Login(request.Email, request.Password);
        var response = new AuthencationResponse
        {
            UserId = loginResult.UserId,
            FirstName = loginResult.FirstName,
            LastName = loginResult.LastName,
            Email = loginResult.Email,
            Token = loginResult.Token
        };
        return Ok(response);
    }

    [HttpPost("auth/register")]
    public IActionResult Register(RegisterRequest request)
    {
        var loginResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
        var response = new AuthencationResponse
        {
            UserId = loginResult.UserId,
            FirstName = loginResult.FirstName,
            LastName = loginResult.LastName,
            Email = loginResult.Email,
            Token = loginResult.Token
        };
        return Ok(response);
    }
}
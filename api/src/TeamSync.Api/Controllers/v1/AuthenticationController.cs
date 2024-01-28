using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamSync.Application.Interfaces;
using TeamSync.Application.Services.Authenication;
using TeamSync.Contracts.Authencation;

namespace TeamSync.Api.v1.Controllers;

public class AuthenticationController : ApiController
{
    private readonly IAuthencticationService _authenticationService;
    private readonly IRequestContext _requestContext;

    public AuthenticationController(IAuthencticationService authService, IRequestContext requestContext)
    {
        _authenticationService = authService;
        _requestContext = requestContext;
    }

    [Authorize]
    [HttpPost("auth/login")]
    public IActionResult Login(LoginRequest request)
    {
        Console.WriteLine("Request context : "+_requestContext.ToString());
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
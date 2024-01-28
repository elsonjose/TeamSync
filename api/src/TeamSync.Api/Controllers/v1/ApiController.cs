using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamSync.Api.v1.Controllers;

[ApiController]
[Route("api/v1")]
public class ApiController : ControllerBase
{
    private ISender? _mediatR;

    public ISender Mediator => _mediatR ??= HttpContext.RequestServices.GetRequiredService<ISender>();

}
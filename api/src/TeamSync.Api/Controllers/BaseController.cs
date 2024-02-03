using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TeamSync.Api.Controllers;

[ApiController]
[Route("api/v1")]
public class BaseController : ControllerBase
{
    private ISender? _mediatR;

    public ISender Mediator => _mediatR ??= HttpContext.RequestServices.GetRequiredService<ISender>();

}
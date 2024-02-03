using Microsoft.AspNetCore.Mvc;
using TeamSync.Application.Requests.Organisation;

namespace TeamSync.Api.Controllers.v1;

public class OrganisationController : BaseController
{
    [HttpPost("organisation/register")]
    public IActionResult RegisterOrganisation([FromBody] OrganisationRegisterCommand organisationRegisterCommand)
    {
        return Ok();
    }

    [HttpPost("organisation/login")]
    public IActionResult LoginOrganisation(OrganisationLoginQuery organisationLoginQuery)
    {
        return Ok();
    }
}

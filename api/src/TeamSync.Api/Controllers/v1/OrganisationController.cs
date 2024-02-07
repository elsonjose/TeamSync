using Microsoft.AspNetCore.Mvc;
using TeamSync.Application.Requests.Organisation;

namespace TeamSync.Api.Controllers.v1;

public class OrganisationController : BaseController
{
    /// <summary>
    /// Registers an organisation.
    /// </summary>
    /// <param name="organisationRegisterCommand"></param>
    /// <returns>ID of the organisation and the authentication token</returns>
    [HttpPost("organisation/register")]
    public async Task<IActionResult> RegisterOrganisation([FromBody] OrganisationRegisterCommand organisationRegisterCommand)
    {
        var response = await Mediator.Send(organisationRegisterCommand);
        return Ok(response);
    }
}

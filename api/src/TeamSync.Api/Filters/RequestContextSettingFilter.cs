using Microsoft.AspNetCore.Mvc.Filters;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure.Authencation;

namespace TeamSync.Api.Filters;
public class RequestContextSettingFilter : IActionFilter
{

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        try
        {
            var httpContext = context.HttpContext;

            var timezoneOffset = Convert.ToInt32(httpContext.Request.Headers[ApiConstants.TimeZoneOffsetHeader.ToLower()]);

            var claims = httpContext.User.Claims;
            var userId = Convert.ToInt32(claims.First(c => c.Type == TeamSyncClaimNames.UserId).Value);
            var organisationId = Convert.ToInt32(claims.First(c => c.Type == TeamSyncClaimNames.OrganisationId).Value);
            var isOrganisation = Convert.ToBoolean(claims.First(c => c.Type == TeamSyncClaimNames.IsOrganisation).Value);

            var requestContext = httpContext.RequestServices.GetRequiredService<IRequestContext>();
            requestContext.SetValues(timezoneOffset, userId, organisationId, isOrganisation);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception " + e);
        }
    }
}
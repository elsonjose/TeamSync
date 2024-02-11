using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Filters;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure.Services.Authencation;

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
            SetRequestContextValues(context);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception " + e);
        }
    }

    private static void SetRequestContextValues(ActionExecutingContext context)
    {
        var httpContext = context.HttpContext;

        var timezoneOffset = Convert.ToInt32(httpContext.Request.Headers[ApiConstants.TimeZoneOffsetHeader.ToLower()]);

        var claims = httpContext.User.Claims;
        var organisationId = claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value ?? null;
        var userId = claims.FirstOrDefault(c => c.Type == TeamSyncClaimNames.UserId)?.Value ?? null;
        var isOrganisation = claims.FirstOrDefault(c => c.Type == TeamSyncClaimNames.IsOrganisation)?.Value ?? "false";

        var requestContext = httpContext.RequestServices.GetRequiredService<IRequestContext>();
        requestContext.SetValues(timezoneOffset, userId, organisationId, isOrganisation);
    }
}
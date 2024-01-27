using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TeamSync.Application.Common.Interfaces;

namespace TeamSync.Infrastructure.Authencation;

/// <summary>
/// Dfines the JWT token generator.
/// </summary>
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(int userId, string firstName, string lastname, int organisationId)
    {

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("5f8da14c5f4738a88d49d808d5db34cacc2cd253499353105ac1e2d0d82f7207")), SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(TeamSyncClaimNames.OrgId,organisationId.ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: "TeamSync",
            audience: "TeamSync",
            expires: _dateTimeProvider.UtcNow.AddHours(1),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
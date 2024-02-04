using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamSync.Application.Interfaces;

namespace TeamSync.Infrastructure.Services.Authencation;

/// <summary>
/// Dfines the JWT token generator.
/// </summary>
public class JwtTokenGenerator : IJwtTokenGenerator
{
    /// <summary>
    /// Specifies the date time provider.
    /// </summary>
    private readonly IDateTimeProvider _dateTimeProvider;

    /// <summary>
    /// Specifies the jwt confiuration.
    /// </summary>
    private readonly JwtSettings _jwtSettings;

    /// <summary>
    /// Initializes a new instance of <seealso cref="JwtTokenGenerator"/>
    /// </summary>
    /// <param name="dateTimeProvider"></param>
    /// <param name="options"></param>
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _jwtSettings = options.Value;
    }

    public string GenerateToken(Guid? userId, Guid organisationId, bool isOrganisation)
    {
        var uid = userId.HasValue ? userId.Value.ToString() : string.Empty;

        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256);

        var claims = new[]{
            new Claim(JwtRegisteredClaimNames.Sub, organisationId.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(TeamSyncClaimNames.UserId, uid),
            new Claim(TeamSyncClaimNames.IsOrganisation, isOrganisation.ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes),
            claims: claims,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
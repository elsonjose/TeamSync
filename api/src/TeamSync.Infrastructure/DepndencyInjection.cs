using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TeamSync.Application.Common;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure.Implementation.Database;
using TeamSync.Infrastructure.Implementations.Hasher;
using TeamSync.Infrastructure.Services;
using TeamSync.Infrastructure.Services.Authencation;

namespace TeamSync.Infrastructure;

/// <summary>
/// Dependency injection for infrastructure.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Defines the method to add infrastructure services for dependency injection.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns>The service collection with added services of instructure.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<HashConfig>(configuration.GetRequiredSection(nameof(HashConfig)));
        services.AddAuth(configuration);
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IHasher, Hasher>();
        services.AddDbContext<ITeamSyncDbContext, TeamSyncDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString(TeamSyncConstants.DefaultConnection));
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSnakeCaseNamingConvention();
        });
        return services;
    }

    /// <summary>
    /// Defines the method to add authentication configuration.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(nameof(JwtSettings), jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });
        return services;
    }
}
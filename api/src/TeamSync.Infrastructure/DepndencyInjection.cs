using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TeamSync.Application.Common.Interfaces;
using TeamSync.Infrastructure.Authencation;
using TeamSync.Infrastructure.Services;

namespace TeamSync.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }
}
using Microsoft.Extensions.DependencyInjection;
using TeamSync.Application.Services.Authenication;

namespace TeamSync.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthencticationService, AuthenicationService>();
        
        return services;
    }
}
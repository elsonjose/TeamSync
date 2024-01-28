using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TeamSync.Application.Services.Authenication;
namespace TeamSync.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IAuthencticationService, AuthenicationService>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}
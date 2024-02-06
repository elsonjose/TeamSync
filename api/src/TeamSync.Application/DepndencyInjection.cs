using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using TeamSync.Application.Requests.Organisation;
namespace TeamSync.Application;

/// <summary>
/// Dependency injection for application.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Defines the method to inject services in TeamSync.Application.
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The service collection with injected services.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<OrganisationRegisterCommandValidator>();
        return services;
    }
}
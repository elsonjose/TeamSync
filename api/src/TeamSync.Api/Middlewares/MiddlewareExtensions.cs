namespace TeamSync.Api.Middlewares;

/// <summary>
/// Defines the middleware extensions.
/// </summary>
public static class MiddlewareExtensions
{
    /// <summary>
    /// Defines the extension for global exception handling.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<GlobalExceptionHandler>();
    }
}
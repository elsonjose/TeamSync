using Microsoft.EntityFrameworkCore;
using TeamSync.Api.Filters;
using TeamSync.Api.Middlewares;
using TeamSync.Application;
using TeamSync.Infrastructure.Implementations;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure;
using TeamSync.Infrastructure.Implementation.Database;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
    .WriteTo.File("logs/log-.txt",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    .MinimumLevel.Debug()
    .CreateLogger();

Log.Information("Starting TeamSync API Service");


var builder = WebApplication.CreateBuilder(args);
{

    builder.Host.UseSerilog();

    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(RequestContextSettingFilter));
    });
    builder.Services.AddSwaggerGen(options =>
    {
        options.OperationFilter<TimeZoneOffsetFilter>();
    });

    builder.Services.AddScoped<IRequestContext, RequestContext>();
    builder.Services.AddTransient<GlobalExceptionHandler>();

    // Dependency injection
    builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);
}

var app = builder.Build();
{
    // Use request logging
    app.UseSerilogRequestLogging();

    // Apply Migrations
    var dbContext = (TeamSyncDbContext)app.Services.CreateScope().ServiceProvider.GetRequiredService(typeof(ITeamSyncDbContext));
    await dbContext.Database.MigrateAsync();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseGlobalExceptionHandler();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


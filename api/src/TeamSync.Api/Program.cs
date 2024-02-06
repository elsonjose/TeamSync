using Microsoft.EntityFrameworkCore;
using TeamSync.Api.Filters;
using TeamSync.Api.Middlewares;
using TeamSync.Application;
using TeamSync.Infrastructure.Implementations;
using TeamSync.Application.Interfaces;
using TeamSync.Infrastructure;
using TeamSync.Infrastructure.Implementation.Database;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(RequestContextSettingFilter));
    });
    builder.Services.AddSwaggerGen(options =>
    {
        options.OperationFilter<TimeZoneOffsetFilter>();
    });

    builder.Services.AddScoped<IRequestContext, RequestContext>();
    builder.Services.AddTransient<IMiddleware, GlobalExceptionHandler>();

    // Dependency injection
    builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);
}

var app = builder.Build();
{
    // Apply Migrations
    var dbContext = (TeamSyncDbContext)app.Services.CreateScope().ServiceProvider.GetRequiredService(typeof(ITeamSyncDbContext));
    await dbContext.Database.MigrateAsync();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


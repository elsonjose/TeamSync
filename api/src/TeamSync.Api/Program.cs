using Microsoft.EntityFrameworkCore;
using TeamSync.Api.Filters;
using TeamSync.Application;
using TeamSync.Application.Implementations;
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

    // Dependency injection
    builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

    // Apply Migrations
    await using var dbContext = new TeamSyncDbContext(builder.Configuration);
    await dbContext.Database.MigrateAsync();
}

var app = builder.Build();
{
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


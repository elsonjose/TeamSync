using TeamSync.Api.Filters;
using TeamSync.Application;
using TeamSync.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen(options =>
    {
        options.OperationFilter<TimeZoneOffsetFilter>();
    });

    // Dependency injection
    builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


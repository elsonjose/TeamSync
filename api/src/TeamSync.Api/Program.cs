using TeamSync.Application;
using TeamSync.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();

    // Dependency injection
    builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices();
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


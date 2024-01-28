using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TeamSync.Api.Filters;

public class TimeZoneOffsetFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= [];
        operation.Parameters.Add(new OpenApiParameter()
        {
            Name = "Timezone-Offset",
            In = ParameterLocation.Header,
            Description = "Timezone offset for the request in minutes.",
            Required = false,
            Schema = new()
            {
                Type = "int",
                Default = new OpenApiString(TimeZoneInfo.Local.BaseUtcOffset.TotalMinutes.ToString())
            }
        });
    }
}
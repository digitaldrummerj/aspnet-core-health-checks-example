using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;

public static class HealthCheckExtensions
{
    public static IEndpointConventionBuilder MapCustomHealthChecks(
        this IEndpointRouteBuilder endpoints,
        string endpointUrl,
        string serviceName)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        var endpointConventionBuilder =
            endpoints.MapHealthChecks(endpointUrl, new HealthCheckOptions
            {
                ResponseWriter = async (context, report) =>
                {
                    string json = JsonSerializer.Serialize(
                        HealthResponse(serviceName, report)
                      , jsonSerializerOptions);

                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(json);
                }
            });

        return endpointConventionBuilder;
    }

    private static HealthResult HealthResponse(string serviceName, HealthReport report)
    {
        return new HealthResult
        {
            Name = serviceName,
            Status = report.Status.ToString(),
            Duration = report.TotalDuration,
            Info = report.Entries
                    .Select(e =>
                        new HealthInfo
                        {
                            Key = e.Key,
                            Description = e.Value.Description,
                            Duration = e.Value.Duration,
                            Status = Enum.GetName(
                                typeof(HealthStatus),
                                e.Value.Status),
                            Error = e.Value.Exception?.Message,
                            Data = e.Value.Data
                        })
                    .ToList()
        };
    }
}

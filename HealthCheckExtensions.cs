using System.Net.Mime;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

public static class HealthCheckExtensions
{
    public static IEndpointConventionBuilder MapCustomHealthChecks (
        this IEndpointRouteBuilder endpoint,
        string endpointUrl,
        string checkName,
        string tagToFilter = ""
    )
    {
        var endpointConventionBuilder = endpoint.MapHealthChecks(
            endpointUrl,
            new HealthCheckOptions
            {
                Predicate = GetFilter(tagToFilter),
                ResponseWriter = async (context, report) => {
                    string json = CreateJsonResponse(report, checkName);
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(json);
                }
            }
        );

        return endpointConventionBuilder;
    }

    private static Func<HealthCheckRegistration, bool> GetFilter (string tag)
    {
        Func<HealthCheckRegistration, bool> filterPredicate =
            filterPredicate = check => check.Tags.Any(t => t == tag);
        if (string.IsNullOrWhiteSpace(tag)) filterPredicate = x => true;

        return filterPredicate;
    }

    private static JsonSerializerOptions GetJsonSerializerOptions()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        return jsonSerializerOptions;
    }
    private static string CreateJsonResponse(HealthReport report, string checkName)
    {
        string json = JsonSerializer.Serialize(
            new
            {
                Name = checkName,
                Status = report.Status.ToString(),
                Duration = report.TotalDuration,
                Info = report.Entries
                    .Select(e =>
                        new
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
            },
            GetJsonSerializerOptions());

        return json;
    }
}

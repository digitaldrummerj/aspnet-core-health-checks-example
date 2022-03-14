namespace AspNetCoreHealthCheckExample;

using Microsoft.Extensions.Diagnostics.HealthChecks;

public class ExampleHealthCheckAsync : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("Health Msg Here."));

        }
        catch (Exception)
        {
            return Task.FromResult(
                new HealthCheckResult(
                    context.Registration.FailureStatus, "Unhealth Msg Here."));
        }
    }
}

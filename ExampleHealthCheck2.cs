namespace AspNetCoreHealthCheckExample;

using Microsoft.Extensions.Diagnostics.HealthChecks;

public class ExampleHealthCheck2Async : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {

            return Task.FromResult(

                HealthCheckResult.Healthy("Health Check 2 Msg Here."));

        }
        catch (Exception)
        {

            return Task.FromResult(

                new HealthCheckResult(

                    context.Registration.FailureStatus, "Unhealthy Check 2 Msg Here."));

        }
    }
}

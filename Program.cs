using AspNetCoreHealthCheckExample;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<ExampleHealthCheckAsync>("Example", tags: new [] { "Example" });

builder.Services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck2Async>("Example2", tags: new[] { "Example2" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });

    endpoints.MapHealthChecks("/health/example", new HealthCheckOptions()
    {
        Predicate = p => p.Tags.Any(t => t == "Example"),
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });

    endpoints.MapHealthChecks("/health/example2", new HealthCheckOptions()
    {
        Predicate = p => p.Tags.Any(t => t == "Example2"),
        ResponseWriter = HealthCheckExtensions.WriteResponse
    });
});

app.Run();

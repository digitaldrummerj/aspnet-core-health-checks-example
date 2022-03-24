# ASP.NET Core Health Check Sample

This is a sample ASP.NET Core Api project to support my posts on ASP.NET Core Health Checks.  You can view the post at [https://digitaldrummerj.me/series/asp.net-core-health-checks/](https://digitaldrummerj.me/series/asp.net-core-health-checks/).

## Branch Descriptions

### [feature/1-plain-text-response](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/1-plain-text-response)

Plain text response which is the default for ASP.NET Core Health Checks.

**If healthy**, return a status of 200 and text response of "Healthy"

**If unhealthy**, return a status of 503 and text response of "Unhealthy"

[see post for details](https://digitaldrummerj.me/aspnet-core-health-checks/)

### [feature/2-json-response](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/2-json-response)

> This branch builds on [feature/1-plain-text-response](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/1-plain-text-response)

Health checks are updated to return a JSON response that shows that status for each health check run and the overall health of the application

```json
{
    "status": "Healthy",
    "duration": "00:00:00.0066738",
    "info":
    [
        {
        "key": "ExampleHealthCheckAsync",
        "description": "Health Msg Here.",
        "duration": "00:00:00.0010113",
        "status": "Healthy",
        "data": {}
        }
    ]
}
```

[see post for details](https://digitaldrummerj.me/aspnet-core-health-checks-json/)

### [feature/3-filter](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/3-filter)

> This branch builds on [feature/2-json-response](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/2-json-response)

This branch shows how to add tags to health check and then only run health checks with those tags.

[see post for details](https://digitaldrummerj.me/aspnet-core-health-checks-filter/)

### [feature/4-generic-endpoint](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/4-generic-endpoint)

> This branch builds on [feature/3-filter](https://github.com/digitaldrummerj/aspnet-core-health-checks-example/tree/feature/3-filter)

This branch will show how to create a generic endpoint for the health checks.

[see post for details](https://digitaldrummerj.me/aspnet-core-health-checks-generic-endpoint/)

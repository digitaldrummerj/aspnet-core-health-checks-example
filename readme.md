# ASP.NET Core Health Check Sample

This is a sample ASP.NET Core Api project to support my posts on ASP.NET Core Health Checks.  You can view the post at [https://digitaldrummerj.me/series/aspnet-core-health-checks/](https://digitaldrummerj.me/series/aspnet-core-health-checks/).

## Branch Descriptions

### [feature/1-plain-text-response](https://github.com/digitaldrummerj/aspnet-core-health-checks/tree/feature/1-plain-text-response)

[see post](https://digitaldrummerj.me/aspnet-core-health-checks/)

Plain text response which is the default for ASP.NET Core Health Checks.

**If healthy**, return a status of 200 and text response of "Healthy"

**If unhealthy**, return a status of 503 and text response of "Unhealthy"

### [feature/2-json-response](https://github.com/digitaldrummerj/aspnet-core-health-checks/tree/feature/2-json-response)

[see post](https://digitaldrummerj.me/aspnet-core-health-checks/aspnet-core-health-checks-json)

> This branch builds on [feature/1-plain-text-response](https://github.com/digitaldrummerj/aspnet-core-health-checks/tree/feature/1-plain-text-response)

Health checks are updated to return a JSON response that shows that status for each health check run and the overall health of the application


```json
{
    "Name":"Example",
    "Status":"Healthy",
    "Duration":"00:00:01.6876124",
    "Info":[
        {
            "Key":"ExampleHealthCheck",
            "Description":"Can connect to Db.",
            "Duration":"00:00:01.2364398",
            "Status":"Healthy"
        }
    ]
}
```

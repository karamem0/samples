using Karamem0.SampleApplication.Models;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = new HostBuilder();
_ = builder.ConfigureFunctionsWorkerDefaults();
_ = builder.ConfigureServices((context, services) =>
    {
        _ = services.AddSingleton<IOpenApiConfigurationOptions>(_ =>
        {
            var options = new OpenApiConfigurationOptions()
            {
                Info = new OpenApiInfo()
                {
                    Version = "1.0.0",
                    Title = "施設予約システム",
                    Description = "施設予約システムの API です。",
                },
                Servers = DefaultOpenApiConfigurationOptions.GetHostNames(),
                OpenApiVersion = OpenApiVersionType.V3,
                IncludeRequestingHostName = true,
                ForceHttps = false,
                ForceHttp = false
            };
            return options;
        });
        _ = services.AddSingleton<ReservationCollection>();
    });

var app = builder.Build();

await app.RunAsync();

//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.Api;

/// <summary>
/// Represents the <b>startup</b> class.
/// </summary>
public class Startup
{
    /// <summary>
    /// The configure services method called by the runtime; use this method to add services to the container.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        // Add the core services.
        services.AddSettings<SampleApplicationSettings>()
                .AddExecutionContext()
                .AddJsonSerializer()
                .AddReferenceDataOrchestrator()
                .AddWebApi()
                .AddJsonMergePatch()
                .AddReferenceDataContentWebApi()
                .AddRequestCache()
                .AddValidationTextProvider()
                .AddValidators<SampleApplicationSettings>()
                .AddSingleton<IIdentifierGenerator, IdentifierGenerator>();

        // Add the database services (scoped per request/connection).
        services.AddDatabase(sp => new SampleApplicationDb(() => new SqlConnection(sp.GetRequiredService<SampleApplicationSettings>().DatabaseConnectionString), sp.GetRequiredService<ILogger<SampleApplicationDb>>()));

        // Add the entity framework services (scoped per request/connection).
        services.AddDbContext<SampleApplicationEfDbContext>();
        services.AddEfDb<SampleApplicationEfDb>();

        // Add the generated reference data services.
        services.AddGeneratedReferenceDataManagerServices()
                .AddGeneratedReferenceDataDataSvcServices()
                .AddGeneratedReferenceDataDataServices();

        // Add the generated entity services.
        services.AddGeneratedManagerServices()
                .AddGeneratedDataSvcServices()
                .AddGeneratedDataServices();

        // Add type-to-type mapping services using reflection.
        services.AddMappers<SampleApplicationSettings>();

        // Add the event publishing; this will need to be updated from the logger publisher to the actual as appropriate.
        services.AddEventDataFormatter()
                .AddEventDataSerializer()
                .AddEventPublisher()
                .AddAzureServiceBusSender()
                .AddAzureServiceBusClient();

        // Add additional services.
        services.AddControllers();
        services.AddHealthChecks();
        services.AddHttpClient();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Karamem0.SampleApplication API", Version = "v1" });
            options.OperationFilter<CoreEx.WebApis.AcceptsBodyOperationFilter>();  // Needed to support AcceptsBodyAttribue where body parameter not explicitly defined.
        });
    }

    /// <summary>
    /// The configure method called by the runtime; use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
    public void Configure(IApplicationBuilder app)
    {
        // Handle any unhandled exceptions.
        app.UseWebApiExceptionHandler();

        // Add Swagger as an endpoint and to serve the swagger-ui to the pipeline.
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Karamem0.SampleApplication"));

        // Add execution context set up to the pipeline.
        app.UseExecutionContext();
        app.UseReferenceDataOrchestrator();

        // Add health checks.
        app.UseHealthChecks("/health");

        // Use controllers.
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

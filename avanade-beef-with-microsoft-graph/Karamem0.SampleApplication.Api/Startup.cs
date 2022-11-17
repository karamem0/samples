//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.IO;
using System.Reflection;
using Azure.Identity;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Caching.Policy;
using Beef.Entities;
using Beef.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.OpenApi.Models;
using Karamem0.SampleApplication.Business;
using Karamem0.SampleApplication.Business.Data;
using Karamem0.SampleApplication.Business.DataSvc;

namespace Karamem0.SampleApplication.Api
{
    /// <summary>
    /// Represents the <b>startup</b> class.
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="config">The <see cref="IConfiguration"/>.</param>
        public Startup(IConfiguration config)
        {
            _config = Check.NotNull(config, nameof(config));

            // Use JSON property names in validation and default the page size.
            ValidationArgs.DefaultUseJsonNames = true;
            PagingArgs.DefaultTake = config.GetValue<int>("BeefDefaultPageSize");
        }

        /// <summary>
        /// The configure services method called by the runtime; use this method to add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // Add the core beef services.
            services.AddBeefExecutionContext()
                    .AddBeefTextProviderAsSingleton()
                    .AddBeefSystemTime()
                    .AddBeefRequestCache()
                    .AddBeefCachePolicyManager(_config.GetSection("BeefCaching").Get<CachePolicyConfig>())
                    .AddBeefWebApiServices()
                    .AddBeefBusinessServices();

            // Add the generated reference data services.
            services.AddGeneratedReferenceDataManagerServices()
                    .AddGeneratedReferenceDataDataSvcServices()
                    .AddGeneratedReferenceDataDataServices();

            // Add the generated entity services.
            services.AddGeneratedManagerServices()
                    .AddGeneratedValidationServices()
                    .AddGeneratedDataSvcServices()
                    .AddGeneratedDataServices();

            // Add GUID identifier generator service.
            services.AddSingleton<IGuidIdentifierGenerator, GuidIdentifierGenerator>();

            // Add AutoMapper services via Assembly-based probing for Profiles.
            services.AddAutoMapper(Beef.Mapper.AutoMapperProfile.Assembly, typeof(UserData).Assembly);

            // Add additional services; note Beef requires NewtonsoftJson.
            services.AddControllers().AddNewtonsoftJson();
            services.AddHealthChecks();
            services.AddHttpClient();

            services.AddSingleton<GraphServiceClient>(services =>
            {
                var credential = new ClientSecretCredential(
                _config.GetValue<string>("MicrosoftGraph:TenantId"),
                _config.GetValue<string>("MicrosoftGraph:ClientId"),
                _config.GetValue<string>("MicrosoftGraph:ClientSecret"));
                var scopes = new[] { "https://graph.microsoft.com/.default" };
                var client = new GraphServiceClient(credential);
                return client;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Karamem0.SampleApplication API", Version = "v1" });

                var xmlName = $"{Assembly.GetEntryAssembly()!.GetName().Name}.xml";
                var xmlFile = Path.Combine(AppContext.BaseDirectory, xmlName);
                if (System.IO.File.Exists(xmlFile))
                    c.IncludeXmlComments(xmlFile);
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        /// <summary>
        /// The configure method called by the runtime; use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/>.</param>
        /// <param name="logger">The <see cref="ILogger{WebApiExceptionHandlerMiddleware}"/>.</param>
        public void Configure(IApplicationBuilder app, ILogger<WebApiExceptionHandlerMiddleware> logger)
        {
            // Add exception handling to the pipeline.
            app.UseWebApiExceptionHandler(logger, _config.GetValue<bool>("BeefIncludeExceptionInInternalServerError"));

            // Add Swagger as a JSON endpoint and to serve the swagger-ui to the pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Karamem0.SampleApplication"));

            // Add execution context set up to the pipeline.
            app.UseExecutionContext();

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
}

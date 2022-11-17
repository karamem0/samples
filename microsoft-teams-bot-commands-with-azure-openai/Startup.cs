//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication;

public class Startup(IConfiguration configuration)
{

    public IConfiguration Configuration { get; } = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddHttpClient().AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
        });
        _ = services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
        _ = services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
        _ = services.AddTransient<IBot, ReservationBot>();
        _ = services.AddTransient(provider => new OpenAIService(
            new OpenAIClient(
                new Uri(this.Configuration.GetValue<string>("AzureOpenAIApiUrl")!),
                new AzureKeyCredential(this.Configuration.GetValue<string>("AzureOpenAIApiKey")!)
            ),
            this.Configuration.GetValue<string>("AzureOpenAIDeploymentName")!
        ));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            _ = app.UseDeveloperExceptionPage();
        }
        _ = app.UseDefaultFiles();
        _ = app.UseStaticFiles();
        _ = app.UseWebSockets();
        _ = app.UseRouting();
        _ = app.UseAuthorization();
        _ = app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        // app.UseHttpsRedirection();
    }
}

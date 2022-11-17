//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure.Blobs;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _ = services.AddHttpClient().AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.MaxDepth = HttpHelper.BotMessageSerializerSettings.MaxDepth;
            });
            _ = services.AddSingleton<BotFrameworkAuthentication, ConfigurationBotFrameworkAuthentication>();
            _ = services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();
            _ = services.AddTransient<IBot, Bots.EchoBot>();
            _ = services.AddSingleton<IStorage>(new BlobsStorage(
                this.Configuration.GetValue<string>("AzureBlobStorageConnectionString"),
                this.Configuration.GetValue<string>("AzureBlobStorageContainerName")));
            _ = services.AddSingleton<ConversationState>();
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
                _ = endpoints.MapControllers();
            });
        }

    }

}

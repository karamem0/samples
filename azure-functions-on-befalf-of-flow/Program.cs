//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

var builder = FunctionsApplication.CreateBuilder(args);

_ = builder.ConfigureFunctionsWebApplication();

var configuration = builder.Configuration;
_ = configuration.AddJsonFile(
    "appsettings.json",
    true,
    true
);

var services = builder.Services;
_ = services.AddApplicationInsightsTelemetryWorkerService();
_ = services.ConfigureFunctionsApplicationInsights();
_ = services.Configure<MicrosoftIdentityOptions>(configuration.GetSection("MicrosoftEntra"));
_ = services.AddMicrosoftIdentityWebApiAuthentication(configuration, "MicrosoftEntra");

var app = builder.Build();
await app.RunAsync();

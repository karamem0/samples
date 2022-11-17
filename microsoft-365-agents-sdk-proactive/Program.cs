//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Karamem0.SampleApplication;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var configuration = builder.Configuration;
_ = configuration.AddJsonFile("appsettings.json");

_ = builder.AddAgent<AgentApplication>();

var services = builder.Services;
_ = services.AddHttpClient();
_ = services.AddHostedService<ProactiveService>();

var app = builder.Build();
await app.RunAsync();

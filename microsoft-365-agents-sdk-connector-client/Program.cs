//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Karamem0.SampleApplication;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

var configuration = builder.Configuration;
_ = configuration.AddJsonFile("appsettings.json");

var services = builder.Services;

_ = services.AddHostedService<ConnectorClientService>();
_ = services.AddHttpClient();
_ = services.AddSingleton<IConnections, ConfigurationConnections>();
_ = services.AddSingleton<IChannelServiceClientFactory, RestChannelServiceClientFactory>();

builder.Build().Run();

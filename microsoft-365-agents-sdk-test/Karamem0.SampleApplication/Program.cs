//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Karamem0.SampleApplication;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.Agents.Storage;

var builder = WebApplication.CreateBuilder(args);

_ = builder.AddAgent<SampleAgent>();

_ = builder.Services.AddHttpClient();
_ = builder.Services.AddSingleton<IStorage, MemoryStorage>();
_ = builder.Services.AddAgentAspNetAuthentication(builder.Configuration);
_ = builder.Services.AddAuthorization();

var app = builder.Build();

_ = app.UseAuthentication();
_ = app.UseAuthorization();
_ = app.MapAgentRootEndpoint();
_ = app.MapAgentApplicationEndpoints(requireAuth: false);

app.Run();

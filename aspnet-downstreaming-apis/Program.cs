//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

_ = services.AddOpenApi();
_ = services
    .AddMicrosoftIdentityWebApiAuthentication(configuration)
    .EnableTokenAcquisitionToCallDownstreamApi()
    .AddMicrosoftGraph(configuration.GetSection("MicrosoftGraph"))
    .AddDownstreamApi("SharePoint", configuration.GetSection("SharePoint"))
    .AddInMemoryTokenCaches();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.MapOpenApi();
}
_ = app.UseHttpsRedirection();
_ = app.UseAuthentication();
_ = app.UseAuthorization();

app.MapGet("/api/graph/me", async (Microsoft.Graph.GraphServiceClient client) =>
    {
        var user = await client.Me.Request().GetAsync();
        return new UserInfo(
            user.Id,
            user.UserPrincipalName,
            user.DisplayName,
            user.Mail
        );
    })
    .RequireAuthorization();

app.MapGet("/api/sharepoint/me", async (IDownstreamApi client) =>
    {
        var response = await client.CallApiForUserAsync(
            "SharePoint",
            options =>
            {
                options.HttpMethod = "POST";
                options.AcceptHeader = "application/json;odata=nometadata";
                options.RelativePath = "_api/sp.userprofiles.profileloader.getprofileloader/getuserprofile";
            }
        );
        var user = await response.Content.ReadFromJsonAsync<UserProfile>();
        return new UserInfo(
            user?.AccountName,
            user?.AccountName?.Split('|').LastOrDefault(),
            user?.DisplayName,
            user?.SipAddress
        );
    })
    .RequireAuthorization();

await app.RunAsync();

public sealed record UserInfo(
    string? Id,
    string? UserPrincipalName,
    string? DisplayName,
    string? Mail
);

public sealed record UserProfile(
    [property: JsonPropertyName("AccountName")] string? AccountName,
    [property: JsonPropertyName("DisplayName")] string? DisplayName,
    [property: JsonPropertyName("SipAddress")] string? SipAddress
);

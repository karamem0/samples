//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Azure.Identity;
using Microsoft.Azure.Functions.Worker;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication;

public class SampleFunction(IOptions<MicrosoftIdentityOptions> options)
{

    private readonly MicrosoftIdentityOptions options = options.Value;

    [Function("SampleFunction")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "GET", "POST")] HttpRequest request)
    {
        var (authenticationStatus, authenticationResponse) = await request.HttpContext.AuthenticateAzureFunctionAsync();
        if (authenticationStatus)
        {
            var authorizationHeader = request.Headers.Authorization.FirstOrDefault()?.Split(" ");
            if (authorizationHeader?.Length == 2 && authorizationHeader[0] == "Bearer")
            {
                var credential = new OnBehalfOfCredential(
                    options.TenantId,
                    options.ClientId,
                    options.ClientSecret,
                    authorizationHeader[1]
                );
                var graphServiceClient = new GraphServiceClient(credential);
                var currentUser = await graphServiceClient.Me.GetAsync();
                return new OkObjectResult(currentUser);
            }
            else
            {
                return new UnauthorizedResult();
            }
        }
        else
        {
            return authenticationResponse ?? new UnauthorizedResult();
        }
    }

}

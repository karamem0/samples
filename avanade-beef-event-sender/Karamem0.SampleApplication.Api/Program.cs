//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.Api;

/// <summary>
/// The <b>Web API</b> host/program.
/// </summary>
public static class Program
{
    /// <summary>
    /// Main startup.
    /// </summary>
    /// <param name="args">The startup arguments.</param>
    public static void Main(string[] args) => Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
        .ConfigureAppConfiguration(c => c.AddEnvironmentVariables("SampleApplication_").AddCommandLine(args))
        .Build().Run();
}

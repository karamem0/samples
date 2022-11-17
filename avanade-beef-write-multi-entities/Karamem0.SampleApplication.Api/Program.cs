//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Beef.AspNetCore.WebApi;
using Microsoft.AspNetCore.Hosting;

namespace Karamem0.SampleApplication.Api
{
    /// <summary>
    /// The <b>Web API</b> host/program.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main startup.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        public static void Main(string[] args) => CreateWebHostBuilder(args).Build().Run();

        /// <summary>
        /// Creates the <see cref="IWebHostBuilder"/> using the <i>Beef</i> <see cref="WebApiStartup"/> capability to create the host with the underlying configuration probing.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        /// <returns>The <see cref="IWebHostBuilder"/>.</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebApiStartup.CreateWebHost<Startup>(args, "SampleApplication");
    }
}

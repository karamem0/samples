//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Beef.Database.Core;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Database
{
    /// <summary>
    /// Represents the <b>database utilities</b> program (capability).
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main startup.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        /// <returns>The status code whereby zero indicates success.</returns>
        public static Task<int> Main(string[] args) => DatabaseConsole.Create("Data Source=.;Initial Catalog=Karamem0.SampleApplication;Integrated Security=True;TrustServerCertificate=true", "Karamem0", "SampleApplication", useBeefDbo: true).RunAsync(args);
    }
}

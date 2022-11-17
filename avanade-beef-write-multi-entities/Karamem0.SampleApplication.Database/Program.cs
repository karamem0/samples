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
        public static Task<int> Main(string[] args) => DatabaseConsole.Create("Data Source=.;Initial Catalog=Company.AppName;Integrated Security=True;TrustServerCertificate=true", "Karamem0", "SampleApplication", useBeefDbo: true).RunAsync(args);
    }
}

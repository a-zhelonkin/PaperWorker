using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Front
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            XmlConfigurator.Configure(
                LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(Hierarchy)),
                File.OpenRead("log4net.config")
            );

            await CreateWebHostBuilder(args).Build().RunAsync();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
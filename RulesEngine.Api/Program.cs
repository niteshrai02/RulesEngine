using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RulesEngine.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LoggerFactory.Create(builder => builder.AddConsole().AddFilter("Critical", LogLevel.Critical)).CreateLogger("Program");
            LogErrors(() => CreateWebHostBuilder(args).Build().Run(), logger);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var contentLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(contentLocation)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(LogLevel.Information);
                });
        }
        internal static void LogErrors(Action action, ILogger logger)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex, "Payment Operation Service failed to execute.");
                throw;
            }
        }
    }
}

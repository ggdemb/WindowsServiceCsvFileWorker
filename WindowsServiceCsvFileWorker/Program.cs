using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WindowsServiceCsvFileWorker.Services;

namespace WindowsServiceCsvFileWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService() //this is 1.Sets the host lifetime to WindowsServiceLifetime 2.Sets the Content Root 3.Enables logging to the event log with the application name as the default source name. It's transparent for debugging.
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddSingleton<IFileProcessService, FileProcessService>();
                });
    }
}

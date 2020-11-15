using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using System.Runtime.InteropServices;

namespace SabreSprings.Brewing.BrewController.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    if (environment == Environments.Development)
                    {

                        webBuilder.UseUrls("http://localhost:8090");
                    }
                    else
                    {
                        webBuilder.UseUrls("http://*:8080");
                    }

                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
            host.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                bool isWindows = System.Runtime.InteropServices.RuntimeInformation
                                               .IsOSPlatform(OSPlatform.Windows);
                if (isWindows)
                {
                    Console.WriteLine("Detected OS: Windows");
                    config.AddJsonFile("appsettings.Windows.Development.json", optional: true, reloadOnChange: true);
                }
                else
                {
                    Console.WriteLine("Detected OS: Linux");
                    config.AddJsonFile("appsettings.Linux.Development.json", optional: true, reloadOnChange: true);
                }
            });
            return host;
        }
    }
}

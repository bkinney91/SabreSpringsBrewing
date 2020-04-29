using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SabreSprings.Brewing.TapHouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    if(environment == Environments.Development){
                        webBuilder.UseUrls("http://localhost:8090");
                    }
                    else{
                         webBuilder.UseUrls("http://*:8080");
                    }
                   
                }).UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}

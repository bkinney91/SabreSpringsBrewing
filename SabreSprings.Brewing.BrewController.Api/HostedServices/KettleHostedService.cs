using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SabreSprings.Brewing.BrewController.Api.Hubs;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.HostedServices
{
    public class KettleHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IKettleService KettleService;
        private readonly IHubContext<KettleHub> KettleHubContext;

        public KettleHostedService(IKettleService kettleService, IHubContext<KettleHub> kettleHubContext)
        {
            KettleService = kettleService;
            KettleHubContext = kettleHubContext;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            int currentTemperature = KettleService.GetCurrentTemperature();
            int targetTemperature = KettleService.GetTargetTemperature();
            Console.WriteLine("Current temperature is " + currentTemperature);
            Console.WriteLine("Target temperature is " + targetTemperature);
            Task.Run(() =>
            {
                KettleHubContext.Clients.All.SendAsync("TargetTemperature", targetTemperature);
                KettleHubContext.Clients.All.SendAsync("CurrentTemperature", currentTemperature);
            });
            
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {    
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

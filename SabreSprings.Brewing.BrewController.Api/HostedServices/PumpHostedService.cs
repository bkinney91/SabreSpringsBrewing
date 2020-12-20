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
using System.Device.Gpio;

namespace SabreSprings.Brewing.BrewController.HostedServices
{
    public class PumpHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private IPumpService PumpService;
        private IHubContext<PumpHub> PumpHubContext;

        public PumpHostedService(IPumpService pumpService, IHubContext<PumpHub> pumpHubContext)
        {
            PumpHubContext = pumpHubContext;    
            PumpService = pumpService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {                
            bool pump1 = PumpService.GetPump1PowerState();
            bool pump2 = PumpService.GetPump2PowerState();  
            Console.WriteLine("Pump1 sending |" + pump1 + "|");
            Console.WriteLine("Pump2 sending |" + pump2 + "|");
            Task.Run(() =>
            {                
                PumpHubContext.Clients.All.SendAsync("Pump1PowerState", pump1);
                PumpHubContext.Clients.All.SendAsync("Pump2PowerState", pump2);
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

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
    public class MashHostedService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IMashService MashService;
        private readonly IHubContext<MashHub> MashHubContext;

        public MashHostedService(IHubContext<MashHub> mashHubContext,
          IMashService mashService)
        {
            MashHubContext = mashHubContext;
            MashService = mashService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {           
            decimal mashTemperature = MashService.GetTemperature();
            //Format for UI
            decimal.Round(mashTemperature, 2, MidpointRounding.AwayFromZero);
            Task.Run(() =>
            {                
                MashHubContext.Clients.All.SendAsync("MashTemperature", mashTemperature);
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

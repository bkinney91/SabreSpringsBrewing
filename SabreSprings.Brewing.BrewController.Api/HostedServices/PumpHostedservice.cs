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
        
      
        private readonly IHubContext<PumpHub> PumpHubContext;
        private const int Pump1PinNumber = 26;
        private const int Pump2PinNumber = 20;
        private GpioController Rpi; 
        private PinValue Pump1Pin = PinValue.Low;
        private PinValue Pump2Pin = PinValue.Low;

        public PumpHostedService(IHubContext<PumpHub> pumpHubContext)
        {
            PumpHubContext = pumpHubContext;    
            Rpi = new GpioController();   
            Rpi.OpenPin(Pump1PinNumber, PinMode.Output);
            Rpi.OpenPin(Pump2PinNumber, PinMode.Output);  
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {                       
            Task.Run(() =>
            {                
                PumpHubContext.Clients.All.SendAsync("Pump1", Pump1Pin == PinValue.High);
                PumpHubContext.Clients.All.SendAsync("Pump2", Pump2Pin == PinValue.High);
            });
            
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {    
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Pump1(bool enablePower){
            if(enablePower)
            {
                Rpi.Write(Pump1PinNumber, PinValue.High);
            }
            else
            {
                Rpi.Write(Pump1PinNumber, PinValue.Low);
            }
        }

        public void Pump2(bool enablePower)
        {
            if(enablePower)
            {
                Rpi.Write(Pump2PinNumber, PinValue.High);
            }
            else
            {
                Rpi.Write(Pump2PinNumber, PinValue.Low);
            }
        }


        public void Dispose()
        {
            Rpi.Dispose();
            _timer?.Dispose();
        }
    }
}

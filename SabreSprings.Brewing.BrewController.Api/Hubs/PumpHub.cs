using Microsoft.AspNetCore.SignalR;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.Api.Hubs
{
  public class PumpHub : Hub
  {
      private readonly IPumpService PumpService;
      public PumpHub(IPumpService pumpService){
          PumpService = pumpService;
      }
       
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }

    public async Task SetPump1PowerState(bool enablePower){
        PumpService.Pump1(enablePower);
        await Clients.All.SendAsync("Pump1PowerState", enablePower);
    }

    public async Task SetPump2PowerState(bool enablePower){
        PumpService.Pump2(enablePower);
        await Clients.All.SendAsync("Pump2PowerState", enablePower);
    }

  }
}
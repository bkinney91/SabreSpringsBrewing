using Microsoft.AspNetCore.SignalR;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.Api.Hubs
{
    public class KettleHub : Hub
    {
        private readonly IKettleService KettleService;
        public KettleHub(IKettleService kettleService)
        {
            KettleService = kettleService;
        }
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }


        public void SetTemperature(int temperature)
        {
            KettleService.SetTemperature(temperature);
        }


    }
}
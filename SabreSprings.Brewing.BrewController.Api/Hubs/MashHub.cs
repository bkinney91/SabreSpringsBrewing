using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.Api.Hubs
{
  public class MashHub : Hub
  {
       
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }


  }
}
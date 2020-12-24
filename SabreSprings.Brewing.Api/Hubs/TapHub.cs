using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Api.Hubs
{
  public class TapHub : Hub
  {
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }
  }
}
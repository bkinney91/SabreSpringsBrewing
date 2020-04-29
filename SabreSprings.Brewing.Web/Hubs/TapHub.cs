using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Web.Hubs
{
  public class TapHub : Hub
  {
    public async Task SendMessage(string message)
    {
      await Clients.All.SendAsync("ReceiveMessage", message);
    }
  }
}
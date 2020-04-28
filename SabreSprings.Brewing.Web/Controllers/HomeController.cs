using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SabreSprings.Brewing.TapHouse.Models;
using SabreSprings.Brewing.Web.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace SabreSprings.Brewing.TapHouse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<TapHub> TapHub;

        public HomeController(ILogger<HomeController> logger, IHubContext<TapHub> tapHub)
        {
            _logger = logger;
            TapHub = tapHub;
        }

        public IActionResult Index()
        {
            
            TapHub.Clients.All.SendAsync("ReceiveMessage","Home bruh");
            return View();

        }

        public IActionResult About()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace SabreSprings.Brewing.TapHouse.Controllers
{
    public class TaproomController : Controller
    {
        public IActionResult OnTap()
        {
            return View();
        }
    }
}
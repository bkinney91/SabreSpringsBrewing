using Microsoft.AspNetCore.Mvc;

namespace SabreSprings.Brewing.TapHouse.Controllers
{
    public class FermentationChartController : Controller
    {
        public IActionResult FermentationChart()
        {
            return View();
        }
    }
}
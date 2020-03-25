using Microsoft.AspNetCore.Mvc;

namespace SabreSprings.Brewing.TapHouse.Controllers
{
    public class FermentationLogController : Controller
    {
        public IActionResult FermentationLog()
        {
            return View();
        }
    }
}
﻿using Microsoft.AspNetCore.Mvc;

namespace SabreSprings.Brewing.Web.Controllers
{
    public class BatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(id);
        }
    }
}
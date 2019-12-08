using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.Domain;
using SabreSprings.Brewing.Services.Interfaces;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapController : ControllerBase
    {
        private readonly ITapService TapService;
        public TapController(ITapService tapService)
        {
            TapService = tapService;
        }

        [Route("GetOnTap")]
        [HttpGet]
        public async Task<IActionResult> GetOnTap()
        {
            List<Tap> tapListDisplays = await TapService.GetOnTap();
            return Ok(tapListDisplays);
        }


    }
}
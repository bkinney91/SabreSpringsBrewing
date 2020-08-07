using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Domain;
using SabreSprings.Brewing.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using SabreSprings.Brewing.Web.Hubs;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapController : ControllerBase
    {
        private readonly ITapService TapService;
        private readonly IHubContext<TapHub> TapHubContext;
        public TapController(ITapService tapService, IHubContext<TapHub> tapHubContext)
        {
            TapService = tapService;
            TapHubContext = tapHubContext;
        }

        [Route("GetOnTap")]
        [HttpGet]
        public async Task<IActionResult> GetOnTap()
        {
            try
            {
                List<Tap> tapListDisplays = await TapService.GetOnTap();
                return Ok(tapListDisplays);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [Route("ProcessPour")]
        [HttpPost]
        public async Task<IActionResult> ProcessPour(Pour pour)
        {
            try
            {
                await TapService.ProcessPour(pour);
                List<Tap> tapListDisplays = await TapService.GetOnTap();
                TapHubContext.Clients.All.SendAsync("TapData", tapListDisplays);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

       

    }
}
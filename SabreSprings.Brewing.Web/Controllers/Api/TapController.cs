using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
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
            try
            {
                List<Tap> tapListDisplays = await TapService.GetOnTap();
                return Ok(tapListDisplays);
            }
            catch(Exception ex)
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
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
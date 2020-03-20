using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Data.Interfaces;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Models.View;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentabuoyLogController : ControllerBase
    {
        private readonly IFermentabuoyLogService FermentabuoyLogService;
        private readonly ILogger Logger;
        public FermentabuoyLogController(IFermentabuoyLogService fermentabuoyLogService, ILogger logger)
        {
            FermentabuoyLogService = fermentabuoyLogService;
            Logger = logger;
        }

        /// <summary>
        /// This method takes in the raw data from a buoy device and puts it into a DTO which is then given to the service layer to be translated into an entity.
        /// </summary>
        /// <param name="fermentabuoyLogDto"> This is the dto received from the buoy raw data</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] FermentabuoyLogDto fermentabuoyLogDto)
        {
            try
            {
                await FermentabuoyLogService.AddFermentabuoyLog(fermentabuoyLogDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


    }
}
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
        
        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] FermentabuoyLogDto fermentabuoyLogDto)
        {
            ///give dto to service function
            try
            {
                await FermentabuoyLogService.addFermentabuoyLog(fermentabuoyLogDto);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

       
    }
}
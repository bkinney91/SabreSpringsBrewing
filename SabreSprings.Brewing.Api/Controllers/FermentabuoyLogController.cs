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

namespace SabreSprings.Brewing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentabuoyLogController : ControllerBase
    {
        private readonly IFermentabuoyLogService FermentabuoyLogService;
        public FermentabuoyLogController(IFermentabuoyLogService fermentabuoyLogService)
        {
            FermentabuoyLogService = fermentabuoyLogService;
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
            await FermentabuoyLogService.AddFermentabuoyLog(fermentabuoyLogDto);
            return NoContent();
        }

        /// <summary>
        /// Get a specific log from the Log ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        [Produces(typeof(FermentabuoyLogDto))]
        public async Task<IActionResult> Get(int id)
        {
            FermentabuoyLogDto log = await FermentabuoyLogService.GetLog(id);
            return Ok(log);
        }

        /// <summary>
        /// returns all logs in the fermentation table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        [Produces(typeof(List<FermentabuoyLogDto>))]
        public async Task<IActionResult> GetAll()
        {
            List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetAllLogs();
            return Ok(logs);
        }

        /// <summary>
        /// returns distinct buoy names in the fermentation table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetBuoyNames")]
        [Produces(typeof(List<FermentabuoyLogDto>))]
        public async Task<IActionResult> GetBuoyNames()
        {
            List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetBuoyNames();
            return Ok(logs);
        }

        /// <summary>
        /// returns all logs for a specific buoy name
        /// </summary>
        /// <param name="buoyName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLogsByBuoy")]
        [Produces(typeof(List<FermentabuoyLogDto>))]
        public async Task<IActionResult> GetLogsByBuoy(string buoyName)
        {
            List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetLogsByBuoy(buoyName);
            return Ok(logs);
        }

        /// <summary>
        /// Gets all logs associated with a batch
        /// </summary>
        /// <param name="batch"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetLogsByBatch")]
        [Produces(typeof(List<FermentabuoyLogDto>))]
        public async Task<IActionResult> GetLogsByBatch(int batch)
        {
            List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetLogsByBatch(batch);
            return Ok(logs);
        }
    }
}
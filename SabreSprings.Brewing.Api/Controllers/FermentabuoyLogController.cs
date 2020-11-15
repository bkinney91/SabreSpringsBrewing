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
            try
            {
                FermentabuoyLogDto log = await FermentabuoyLogService.GetLog(id);
                return Ok(log);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
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
            try
            {
                List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetAllLogs();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
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
            try
            {
                List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetBuoyNames();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
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
            try
            {
                List<FermentabuoyLogDto> logs = await FermentabuoyLogService.GetLogsByBuoy(buoyName);
                return Ok(logs);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
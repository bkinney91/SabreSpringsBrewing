using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.BrewController.Api.Models;
using SabreSprings.Brewing.BrewController.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.BrewController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KettleController : ControllerBase
    {
        private readonly IKettleService KettleService;
        public KettleController(IKettleService kettleService)
        {
            KettleService = kettleService;
        }


        [Route("SetTemperature")]
        [HttpPost]
        public async Task<IActionResult> SetTemperature(KettleTemperatureDto dto)
        {
            try
            {
                KettleService.SetTemperature(dto.Temperature);                
                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Models.Entities;
using SabreSprings.Brewing.Services;
using SabreSprings.Brewing.Services.Interfaces;

namespace SabreSprings.Brewing.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentabuoyController : ControllerBase
    {
        private readonly IFermentabuoyService FermentabuoyService;

        public FermentabuoyController(IFermentabuoyService fermentabuoyService)
        {
            FermentabuoyService = fermentabuoyService;
        }

        [HttpGet]
        [Route("GetSummary")]
        public async Task<IActionResult> GetSummary()
        {
            try
            {
                List<FermentabuoySummaryDto> summary = await FermentabuoyService.GetFermentabuoySummary();
                return Ok(summary);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }



        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                FermentabuoyDto fermentabouy = await FermentabuoyService.GetFermentabuoy(id);
                return Ok(fermentabouy);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post(FermentabuoyDto dto)
        {
            try
            {
                await FermentabuoyService.AddFermentabuoy(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }


        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put(FermentabuoyDto dto)
        {
            try
            {
                await FermentabuoyService.UpdateFermentabuoy(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }




    }
}
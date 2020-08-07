using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
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

    }
}
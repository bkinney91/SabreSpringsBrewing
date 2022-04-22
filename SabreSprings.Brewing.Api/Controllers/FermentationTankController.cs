using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FermentationTankController : ControllerBase
    {
        private readonly IFermentationTankService FermentationTankService;

        public FermentationTankController(IFermentationTankService fermentationTankService)
        {
            this.FermentationTankService = fermentationTankService;
        }


         [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                FermentationTankDto tank = await FermentationTankService.GetFermentationTank(id);
                return Ok(tank);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<FermentationTankDto> tanks = await FermentationTankService.GetFermentationTanks();
                return Ok(tanks);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}

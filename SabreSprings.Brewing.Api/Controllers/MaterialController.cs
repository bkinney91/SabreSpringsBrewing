using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SabreSprings.Brewing.Models.DataTransfer;
using SabreSprings.Brewing.Services.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SabreSprings.Brewing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService MaterialService;
        public MaterialController(IMaterialService materialService)
        {
            MaterialService = materialService;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                MaterialDto Material = await MaterialService.GetMaterial(id);
                return Ok(Material);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Material.");
                throw;
            }
        }



        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] MaterialDto dto)
        {
            try
            {
                await MaterialService.Add(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding Material.");
                throw;
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] MaterialDto dto)
        {
            try
            {
                await MaterialService.Update(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating Material with ID \"{id}\".");
                throw;
            }
        }
    }
}

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
    public class RecipeMaterialController : ControllerBase
    {
        private readonly IRecipeMaterialService RecipeMaterialService;
        public RecipeMaterialController(IRecipeMaterialService recipeMaterialService)
        {
            RecipeMaterialService = recipeMaterialService;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                RecipeMaterialDto RecipeMaterial = await RecipeMaterialService.GetRecipeMaterial(id);
                return Ok(RecipeMaterial);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe Step.");
                throw;
            }
        }



        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] RecipeMaterialDto dto)
        {
            try
            {
                await RecipeMaterialService.Add(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding Recipe Step.");
                throw;
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] RecipeMaterialDto dto)
        {
            try
            {
                await RecipeMaterialService.Update(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating Recipe Step with ID \"{id}\".");
                throw;
            }
        }

        [HttpGet]
        [Route("GetRecipeMaterials")]
        public async Task<IActionResult> GetRecipeMaterials(int recipeId)
        {
             
             try
            {
                List<RecipeMaterialDto> steps = await RecipeMaterialService.GetRecipeMaterials(recipeId);
                return Ok(steps);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe Materials.");
                throw;
            }
        }
    }
}

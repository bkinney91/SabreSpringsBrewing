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
    public class RecipeStepController : ControllerBase
    {
        private readonly IRecipeStepService RecipeStepService;
        public RecipeStepController(IRecipeStepService recipeStepService)
        {
            RecipeStepService = recipeStepService;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                RecipeStepDto recipeStep = await RecipeStepService.Get(id);
                return Ok(recipeStep);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe Step.");
                throw;
            }
        }



        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] RecipeStepDto dto)
        {
            try
            {
                await RecipeStepService.Add(dto);
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
        public async Task<IActionResult> Put([FromBody] RecipeStepDto dto)
        {
            try
            {
                await RecipeStepService.Update(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating Recipe Step with ID \"{id}\".");
                throw;
            }
        }

        [HttpGet]
        [Route("GetRecipeSteps")]
        public async Task<IActionResult> GetRecipeSteps(int recipeId)
        {
             
             try
            {
                List<RecipeStepDto> steps = await RecipeStepService.GetRecipeSteps(recipeId);
                return Ok(steps);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe Step.");
                throw;
            }
        }
    }
}

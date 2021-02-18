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
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService RecipeService;
        public RecipeController(IRecipeService recipeService)
        {
            RecipeService = recipeService;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                RecipeDto recipe = await RecipeService.GetRecipe(id);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe.");
                throw;
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetByBeer(int beer)
        {
            try
            {
                RecipeDto recipe = await RecipeService.GetRecipeByBeer(beer);
                return Ok(recipe);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error getting Recipe.");
                throw;
            }
        }



        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] RecipeDto dto)
        {
            try
            {
                await RecipeService.AddRecipe(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding Recipe.");
                throw;
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] RecipeDto dto)
        {
            try
            {
                await RecipeService.UpdateRecipe(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating Recipe with ID \"{id}\".");
                throw;
            }
        }
    }
}
